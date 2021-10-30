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
    public class TaskTypeFunction : BaseFunction
    {
        [FunctionName("GetTaskTypes")]
        public async Task<IActionResult> GetTaskTypes([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "taskTypes")] HttpRequest req, ILogger log)
        {
            var taskTypes = await Context.TaskType.ToListAsync();

            IQueryable<TaskType> result = taskTypes.AsQueryable();

            return new OkObjectResult(result);
        }

        [FunctionName("GetTaskTypeById")]
        public static IActionResult GetTaskTypeById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "taskType/{id}")] HttpRequest req, int id, ILogger log)
        {
            var taskType = Context.TaskType.Where(x => x.Id == id);

            IQueryable<TaskType> result = taskType.AsQueryable();

            return new OkObjectResult(result);
        }
    }
}
