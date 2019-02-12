using System.IO;
using System.Threading.Tasks;
using BugTracker.BL.Operations.Issues.Commands;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace BugTracker.Api.Infrastructure.Binders
{
    public class CreateIssueCommandBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            using (var bodyStreamReader = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                using (var jsonTextReader = new JsonTextReader(bodyStreamReader))
                {
                    bindingContext.Result =
                        ModelBindingResult.Success(
                            new JsonSerializer().Deserialize<CreateIssueCommand>(jsonTextReader));
                    return Task.CompletedTask;
                }
            }
        }
    }
}