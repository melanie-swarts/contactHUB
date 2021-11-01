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
using ContactHub.WebApi.Models;
using ContactHub.WebAPI.Properties;
using ContactHub.WebAPI.Mappers;

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

        [FunctionName("CreateCalendarEventType")]
        public async Task<IActionResult> CreateCalendarEventType([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "calendarEventTypes/createEventType")] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var eventTypeDetails = JsonConvert.DeserializeObject<CalendarEventType>(requestBody);

            Context.CalendarEventType.Add(eventTypeDetails);
            Context.SaveChanges();

            return new OkObjectResult(Resources.ResourceManager.GetString("SuccessMessage_UserRegistration"));

        }
    }
}
