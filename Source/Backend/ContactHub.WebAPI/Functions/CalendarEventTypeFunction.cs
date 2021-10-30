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
    public class CalendarEventTypeFunction: BaseFunction
    {
        [FunctionName("GetCalendarEventTypes")]
        public async Task<IActionResult> GetCalendarEventTypes([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "calendarEventTypes")] HttpRequest req, ILogger log)
        {
            var calendarEventTypes = await Context.CalendarEventType.ToListAsync();

            IQueryable<CalendarEventType> result = calendarEventTypes.AsQueryable();

            return new OkObjectResult(result);
        }

        [FunctionName("GetCalendarEventTypeById")]
        public static IActionResult GetCalendarEventTypeById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "calendarEventTypes/{id}")] HttpRequest req, int id, ILogger log)
        {
            var calendarEventType = Context.CalendarEventType.Where(x => x.Id == id);

            IQueryable<CalendarEventType> result = calendarEventType.AsQueryable();

            return new OkObjectResult(result);
        }
    }
}
