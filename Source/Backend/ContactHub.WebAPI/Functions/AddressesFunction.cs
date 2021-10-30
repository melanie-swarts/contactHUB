using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ContactHub.Data.Models;

namespace ContactHub.WebAPI.Functions
{
    public class AddressesFunction: BaseFunction
    {
        [FunctionName("GetAddresses")]
        public async Task<IActionResult> GetAddresses([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "addresses")] HttpRequest req, ILogger log)
        {
            var addresses = await Context.Address.ToListAsync();

            IQueryable<Address> result = addresses.AsQueryable();

            return new OkObjectResult(result);
        }

        [FunctionName("GetAddressesById")]
        public static IActionResult GetCountryById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "addresses/{id}")] HttpRequest req, int id, ILogger log)
        {
            var address = Context.Address.Where(x => x.Id == id);

            IQueryable<Address> result = address.AsQueryable();

            return new OkObjectResult(result);
        }
    }
}
