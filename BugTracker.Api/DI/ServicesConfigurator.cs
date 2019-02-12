using BugTracker.BL.Dal;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Operations.Issues.Commands;
using BugTracker.BL.Operations.Issues.Services;
using BugTracker.BL.Validation.Abstract;
using BugTracker.BL.Validation.Issues;
using BugTracker.Operations.Issues.OperationServices;
using BugTracker.Storage.Dal;
using BugTracker.Storage.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BugTracker.Api.DI
{
    public static class ServicesConfigurator
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services.AddDbContext<DatabaseContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("BugTrackerDatabase")))
                .AddScoped<IRepository<Issue>, IssueRepository>()
                .AddScoped<ICreateIssueOperationService, CreateIssueOperationService>()
                .AddScoped<IRenameIssueOperationService, RenameIssueOperationService>()
                .AddScoped<IAddNoteToIssueOperationService, AddNoteToIssueOperationService>()
                .AddScoped<IGetIssueOperationService, GetIssueOperationService>()
                .AddScoped<ICommandValidator<AddNoteToIssueCommand>, AddNoteCommandToIssueValidator>();
        }
    }
}