using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using ContactHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.Cors;

namespace ContactHub.WebAPI.Functions
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserAddressFunction: BaseFunction
    {
        [FunctionName("GetUserAddressById")]
        public IActionResult GetUserAddressById([HttpTrigger(AuthorizationLevel.Function, "get", Route = "address/{id}")] HttpRequest req, int id, ILogger log)
        {
            var userAddress = Context.Address.Where(x => x.Id == id);

            IQueryable<Address> result = userAddress.AsQueryable();

            return new OkObjectResult(result);
        }
    }
}
