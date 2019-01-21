using System.IO;
using System.Threading.Tasks;
using BugTracker.BL.Operations.Issues.Commands;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;

namespace BugTracker.Api.Binders
{
    public class CreateIssueCommandBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            string body;
            using (var bodyStreamReader = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                body = bodyStreamReader.ReadToEnd();
            }

            if (string.IsNullOrEmpty(body))
            {
                return Task.CompletedTask;
            }

            var bodyJObject = JObject.Parse(body);

            if (bodyJObject.TryGetValue(nameof(CreateIssueCommand.Notes), out var notes) && bodyJObject.TryGetValue(nameof(CreateIssueCommand.Title), out var title))
            {
                bindingContext.Result = ModelBindingResult.Success(new CreateIssueCommand((string)title, (string)notes));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }

}
