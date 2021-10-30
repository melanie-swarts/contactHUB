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
    public class TaskFunction : BaseFunction
    {
        [FunctionName("GetTasks")]
        public async Task<IActionResult> GetTask([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "tasks")] HttpRequest req, ILogger log)
        {
            var tasks = await Context.Tasks.ToListAsync();

            IQueryable<Tasks> result = tasks.AsQueryable();

            return new OkObjectResult(result);
        }

        [FunctionName("GetTaskById")]
        public static IActionResult GetTaskById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "task/{id}")] HttpRequest req, int id, ILogger log)
        {
            var task = Context.Tasks.Where(x => x.Id == id);

            IQueryable<Tasks> result = task.AsQueryable();

            return new OkObjectResult(result);
        }
    }
}
