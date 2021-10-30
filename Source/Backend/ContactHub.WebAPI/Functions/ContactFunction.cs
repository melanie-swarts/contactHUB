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
    public class ContactFunction: BaseFunction
    {
        [FunctionName("GetContacts")]
        public async Task<IActionResult> GetContacts([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "contacts")] HttpRequest req, ILogger log)
        {
            var contacts = await Context.Contact.ToListAsync();

            IQueryable<Contact> result = contacts.AsQueryable();

            return new OkObjectResult(result);
        }

        [FunctionName("GetContactById")]
        public static IActionResult GetContactById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "contact/{id}")] HttpRequest req, int id, ILogger log)
        {
            var contact = Context.Contact.Where(x => x.Id == id);

            IQueryable<Contact> result = contact.AsQueryable();

            return new OkObjectResult(result);
        }
    }
}
