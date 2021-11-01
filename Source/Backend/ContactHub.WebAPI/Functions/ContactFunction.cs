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
using ContactHub.WebApi.Models;
using System.Linq;
using ContactHub.WebAPI.Mappers;
using ContactHub.WebAPI.Properties;

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

        [FunctionName("CreateContact")]
        public async Task<IActionResult> CreateContact([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "contact/createContact")] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var contactDetails = JsonConvert.DeserializeObject<Contact>(requestBody);

            Context.Contact.Add(ContactMapper.MapForCreate(contactDetails));
            Context.SaveChanges();

            return new OkObjectResult(contactDetails);

        }

        [FunctionName("UpdateContact")]
        public async Task<IActionResult> UpdateContact([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "contact/updateContact")] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var contactDetails = JsonConvert.DeserializeObject<Contact>(requestBody);

            Context.Contact.Update(contactDetails);
            Context.SaveChanges();

            return new OkObjectResult("Ok");

        }
    }
}
