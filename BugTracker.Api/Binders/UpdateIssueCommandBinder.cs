using System.IO;
using System.Threading.Tasks;
using BugTracker.BL.Operations.Issues.Commands;
using BugTracker.BL.Operations.Issues.Commands.Abstract;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;

namespace BugTracker.Api.Binders
{
    public class UpdateIssueCommandBinder : IModelBinder
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

            if (bodyJObject.TryGetValue(nameof(IUpdateIssueCommand.Id), out var id))
            {
                if (bodyJObject.TryGetValue(nameof(RenameIssueCommand.Title), out var title))
                {
                    bindingContext.Result = ModelBindingResult.Success(new RenameIssueCommand((long)id, (string)title));
                    return Task.CompletedTask;
                }

                if (bodyJObject.TryGetValue(nameof(AddNoteToIssueCommand.Note), out var note))
                {
                    bindingContext.Result = ModelBindingResult.Success(new AddNoteToIssueCommand((long)id, (string)note));
                    return Task.CompletedTask;
                }
            }

            return Task.CompletedTask;
        }
    }
}
