using BugTracker.BL.Dal;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Operations.Audit.ReadModels;
using BugTracker.BL.Operations.Audit.Services;
using BugTracker.BL.Operations.Issues.Commands;
using BugTracker.BL.Operations.Issues.Services;
using BugTracker.BL.Validation.Abstract;
using BugTracker.BL.Validation.Issues;
using BugTracker.Operations.Audit.OperationServices;
using BugTracker.Operations.Issues.OperationServices;
using BugTracker.Storage.Audit;
using BugTracker.Storage.Dal;
using BugTracker.Storage.ReadModels;
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
                    options.UseSqlServer(configuration.GetConnectionString("BugTrackerDatabase"),
                        b => b.MigrationsAssembly("BugTracker.Api")))
                .AddScoped<IRepository<Issue>, IssueRepository>()
                .AddScoped<IRepository<PerformedOperation>, PerformedOperationRepository>()
                .AddScoped<IRepository<EntityChange>, EntityChangeRepository>()
                .AddScoped<ICreateIssueOperationService, CreateIssueOperationService>()
                .AddScoped<IRenameIssueOperationService, RenameIssueOperationService>()
                .AddScoped<IAddNoteToIssueOperationService, AddNoteToIssueOperationService>()
                .AddScoped<IGetIssueChangesOperationService, GetIssueChangesOperationService>()
                .AddScoped<IGetEntityChangesOperationService, GetEntityChangesOperationService>()
                .AddScoped<IAuditService, AuditService>()
                .AddScoped<IGetIssueOperationService, GetIssueOperationService>()
                .AddScoped<ICommandValidator<AddNoteToIssueCommand>, AddNoteToIssueCommandValidator>()
                .AddScoped<ICommandValidator<CreateIssueCommand>, CreateIssueCommandValidator>()
                .AddScoped<ICommandValidator<RenameIssueCommand>, RenameIssueCommandValidator>()
                .AddScoped<IPerformedOperationReadModel, PerformedOperationReadModel>();
        }
    }
}