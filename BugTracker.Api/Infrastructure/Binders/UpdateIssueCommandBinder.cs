using System;
using System.IO;
using System.Threading.Tasks;
using BugTracker.Api.Infrastructure.Binders.Enums;
using BugTracker.BL.Operations.Issues.Commands;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BugTracker.Api.Infrastructure.Binders
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

            if (string.IsNullOrEmpty(body)) return Task.CompletedTask;

            var result = Enum.TryParse<UpdateCommandType>((string) JObject.Parse(body)["_type"], out var commandType);

            if (!result)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

            switch (commandType)
            {
                case UpdateCommandType.AddNote:
                    bindingContext.Result =
                        ModelBindingResult.Success(JsonConvert.DeserializeObject<AddNoteToIssueCommand>(body));
                    break;
                case UpdateCommandType.Rename:
                    bindingContext.Result =
                        ModelBindingResult.Success(JsonConvert.DeserializeObject<RenameIssueCommand>(body));
                    break;
                default:
                    bindingContext.Result = ModelBindingResult.Failed();
                    break;
            }

            return Task.CompletedTask;
        }
    }
}