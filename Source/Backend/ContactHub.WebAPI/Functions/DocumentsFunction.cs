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
    public class DocumentFunction : BaseFunction
    {
        [FunctionName("GetDocuments")]
        public async Task<IActionResult> GetDocuments([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "documents")] HttpRequest req, ILogger log)
        {
            var documents = await Context.Documents.ToListAsync();

            IQueryable<Documents> result = documents.AsQueryable();

            return new OkObjectResult(result);
        }

        [FunctionName("GetDocumentById")]
        public static IActionResult GetDocumentById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Document/{id}")] HttpRequest req, int id, ILogger log)
        {
            var document = Context.Documents.Where(x => x.Id == id);

            IQueryable<Documents> result = document.AsQueryable();

            return new OkObjectResult(result);
        }
    }
}
