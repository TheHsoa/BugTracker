
using BugTracker.BL.Dal;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Operations.Issues.Services;
using BugTracker.Operations.Issues.OperationServices;
using BugTracker.Storage.Dal;
using BugTracker.Storage.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BugTracker.Api.DI
{
    public static class ServicesConfigurator
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            return services.AddSingleton<DatabaseContext>()
                           .AddSingleton<IRepository<Issue>, IssueRepository>()
                           .AddSingleton<ICreateIssueOperationService, CreateIssueOperationService>()
                           .AddSingleton<IUpdateIssueOperationService, UpdateIssueOperationService>()
                           .AddSingleton<IGetIssueOperationService, GetIssueOperationService>();
        }
    }
}
