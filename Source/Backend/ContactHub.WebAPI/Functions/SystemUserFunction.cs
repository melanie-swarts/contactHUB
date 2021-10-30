using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using ContactHub.WebAPI.Models;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using ContactHub.WebAPI.Mappers;
using ContactHub.WebAPI.Properties;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Web.Http.Cors;
using ContactHub.Data.Models;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace ContactHub.WebAPI.Functions
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SystemUserFunction: BaseFunction
    {
        private const string SecurityAlgorithm = "HmacSHA256";
        private const string HashSalt = "ZhHDsf4ndjfscjMmvdQtb3ZH";

        [FunctionName("GetSystemUsers")]
        public static IActionResult GetSystemUsers([HttpTrigger(AuthorizationLevel.Function, "get", Route = "systemUser")] HttpRequest req, ILogger log)
        {
            var systemUsers = Context.SystemUser.ToList();

            IQueryable<SystemUser> result = systemUsers.AsQueryable();

            return new OkObjectResult(result);
        }

        [FunctionName("GetSystemUserById")]
        public static IActionResult GetSystemUserId([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "systemUser/{id}")] HttpRequest req, int id, ILogger log)
        {
            var systemUser = Context.SystemUser.Where(x => x.Id == id);

            IQueryable<SystemUser> result = systemUser.AsQueryable();

            return new OkObjectResult(result);
        }
        
        [FunctionName("GetApplicationUserById")]
        public static IActionResult GetApplicationUserById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "applicationUser/{id}")] HttpRequest req, string id, ILogger log)
        {
            var applicationUser = Context.AspNetUser.Where(x => x.Id == id);

            IQueryable<AspNetUser> result = applicationUser.AsQueryable();

            return new OkObjectResult(result);
        }

        [FunctionName("AuthenticateSystemUser")]
        public async Task<IActionResult> AuthenticateSystemUser([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "systemUser/authenticate")] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var userDetails = JsonConvert.DeserializeObject<AuthenticateModel>(requestBody);

            //check if user exists
            var user = Context.AspNetUser.SingleOrDefault(x => x.UserName == userDetails.username);

            //if user doesn't exist || email is not confirmed || check if password is correct
            if (user == null || user.EmailConfirmed == false || !VerifyPasswordHash(userDetails.password, Convert.FromBase64String(user.SecurityStamp), user.PasswordHash))
                return new BadRequestObjectResult(Resources.ResourceManager.GetString("ErrorMessage_InvalidLogin"));

            //authentication successful, generate token
            var token = generateToken(user.Id, user.Email, Context.SystemUser.Any(x => x.AspNetUserId == user.Id));

            return new OkObjectResult(token);
        }

        [FunctionName("CreateAspNetUser")]
        public async Task<IActionResult> CreateAspNetUser([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "systemUser/register")] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var userDetails = JsonConvert.DeserializeObject<AuthenticateModel>(requestBody);

            //check if user already exists
            var user = Context.AspNetUser.SingleOrDefault(x => x.UserName == userDetails.username);
            
            if (user != null)
                return new ObjectResult(Resources.ResourceManager.GetString("ErrorMessage_EmailExists"));

            Tuple<string, string> hashPassword = CreatePasswordHash(userDetails.password);

            Context.AspNetUser.Add(SystemUserMapper.MapForRegister(userDetails.username, hashPassword));
            Context.SaveChanges();

            return new OkObjectResult(Resources.ResourceManager.GetString("SuccessMessage_UserRegistration"));

        }

        [FunctionName("CreateSystemUser")]
        public async Task<IActionResult> CreateSystemUser([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "systemUser/createAccount")] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var userDetails = JsonConvert.DeserializeObject<SystemUser>(requestBody);

            //check if user already exists
            var user = Context.SystemUser.SingleOrDefault(x => x.AspNetUserId == userDetails.AspNetUserId);

            if (user != null)
                return new ObjectResult(Resources.ResourceManager.GetString("ErrorMessage_UserExists")); 

            Context.SystemUser.Add(SystemUserMapper.MapForCreate(userDetails));
            Context.SaveChanges();

            return new OkObjectResult(Resources.ResourceManager.GetString("SuccessMessage_UserRegistration"));

        }

        [FunctionName("ResetSystemUserPassword")]
        public async Task<IActionResult> ResetSystemUserPassword([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "systemUser/resetPassword")] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var userDetails = JsonConvert.DeserializeObject<AuthenticateModel>(requestBody);

            //check if user exists
            var user = Context.AspNetUser.SingleOrDefault(x => x.UserName == userDetails.username);

            if (user == null)
                return new BadRequestObjectResult(Resources.ResourceManager.GetString("ErrorMessage_NoUserFound"));

            //geneate token in email auth

            return new OkObjectResult(Resources.ResourceManager.GetString("SuccessMessage_PasswordReset"));

        }

        [FunctionName("SetSystemUserPassword")]
        public async Task<IActionResult> SetSystemUserPassword([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "systemUser/setNewPassword")] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var userDetails = JsonConvert.DeserializeObject<AuthenticateModel>(requestBody);

            //geneate token in email auth

            //check if user exists
            var user = Context.AspNetUser.SingleOrDefault(x => x.UserName == userDetails.username);

            if (user == null)
                return new BadRequestObjectResult(Resources.ResourceManager.GetString("ErrorMessage_NoUserFound"));

            Tuple<string, string> hashPassword = CreatePasswordHash(userDetails.password);

            Context.AspNetUser.Update(SystemUserMapper.MapForPasswordReset(user, hashPassword));
            Context.SaveChanges();

            return new OkObjectResult(Resources.ResourceManager.GetString("SuccessMessage_PasswordUpdate"));

        }

        private static bool VerifyPasswordHash(string password, byte[] salt, string storedHash)
        {
            if (ComputeHash(password, salt) != storedHash) return false;

            return true;
        }

        private static Tuple<string, string> CreatePasswordHash(string password)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            byte[] salt = new byte[256 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Tuple.Create(ComputeHash(password, salt), Convert.ToBase64String(salt));
        }

        private static string ComputeHash(string password, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10000,
                    numBytesRequested: 512 / 8));
        }

        public static string generateToken(string userId, string userEmail, bool userProfileExists)
        {
            string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var header = new JwtHeader(credentials);

            var payload = new JwtPayload
            {
                { "identifier", userId },
                { "user",  userEmail},
                { "userProfile", userProfileExists},
                { "role", "user"},
            };

            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(secToken);
        }

    }
}
