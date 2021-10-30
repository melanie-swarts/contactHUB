using System;
using ContactHub.Data.Models;

namespace ContactHub.WebAPI.Mappers
{
    public class SystemUserMapper
        {
            public static AspNetUser MapForRegister(string userName, Tuple<string, string> hashPassword)
            {
                return new AspNetUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = userName,
                    EmailConfirmed = true, //set true as no email functionality is built into this app
                    PasswordHash = hashPassword.Item1,
                    SecurityStamp = hashPassword.Item2,
                    UserName = userName
                };
            }

            public static AspNetUser MapForPasswordReset(AspNetUser user, Tuple<string, string> hashPassword)
            {
                user.PasswordHash = hashPassword.Item1;
                user.SecurityStamp = hashPassword.Item2;

                return user;
            }

        public static SystemUser MapForCreate(SystemUser systemUser)
        {
            return new SystemUser
            {
                AspNetUserId = systemUser.AspNetUserId,
                FirstName = systemUser.FirstName,
                LastName = systemUser.LastName,
                PrimaryContactNumber = systemUser.PrimaryContactNumber,
                MobileNumber = systemUser.MobileNumber,
                HomeNumber = systemUser.HomeNumber,
                WorkNumber = systemUser.WorkNumber,
                CreatedAt = DateTime.Now
            };
        }
    }
    }
