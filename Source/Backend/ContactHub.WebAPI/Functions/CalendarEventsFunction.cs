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
using ContactHub.Data.Models;
using System.Linq;

namespace ContactHub.WebAPI.Functions
{
    public class CalendarEventsFunction: BaseFunction
    {
        [FunctionName("GetCalendarEvent")]
        public async Task<IActionResult> GetCalendarEvents([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "calendarEvents")] HttpRequest req, ILogger log)
        {
            var calendarEvents = await Context.CalendarEvents.ToListAsync();

            IQueryable<CalendarEvents> result = calendarEvents.AsQueryable();

            return new OkObjectResult(result);
        }

        [FunctionName("GetCalendarEventById")]
        public static IActionResult GetCalendarEventById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "calendarEvent/{id}")] HttpRequest req, int id, ILogger log)
        {
            var calendarEvent = Context.CalendarEvents.Where(x => x.Id == id);

            IQueryable<CalendarEvents> result = calendarEvent.AsQueryable();

            return new OkObjectResult(result);
        }
    }
}
