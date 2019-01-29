using BugTracker.Api.Infrastructure.Binders;
using BugTracker.BL.Operations.Issues.Commands;
using BugTracker.BL.Operations.Issues.Commands.Abstract;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BugTracker.Api.Infrastructure.BinderProviders
{
    public sealed class IssueCommandBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinder _updateBinder = new UpdateIssueCommandBinder();
        private readonly IModelBinder _createBinder = new CreateIssueCommandBinder();

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(IUpdateIssueCommand) ? _updateBinder :
                context.Metadata.ModelType == typeof(CreateIssueCommand) ? _createBinder : null;
        }
    }
}
