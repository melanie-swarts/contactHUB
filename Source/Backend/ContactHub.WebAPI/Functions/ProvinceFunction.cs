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
    public class ProvinceFunction : BaseFunction
    {
        [FunctionName("GetProvince")]
        public async Task<IActionResult> GetProvince([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "provinces")] HttpRequest req, ILogger log)
        {
            var provinces = await Context.Province.ToListAsync();

            IQueryable<Province> result = provinces.AsQueryable();

            return new OkObjectResult(result);
        }

        [FunctionName("GetProvinceById")]
        public static IActionResult GetDocumentById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "province/{id}")] HttpRequest req, int id, ILogger log)
        {
            var province = Context.Province.Where(x => x.Id == id);

            IQueryable<Province> result = province.AsQueryable();

            return new OkObjectResult(result);
        }
    }
}
