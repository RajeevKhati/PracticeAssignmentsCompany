using Company.Project.EventDomain.Data;
using Company.Project.EventDomain.Data.DBContext;
using Company.Project.EventDomain.Repository;
using Company.Project.EventDomain.UoW;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.EventDomain.Configuration
{ /// <summary>
  /// Unit of work service
  /// </summary>
    public static class ExtensionUnitOfWorkService
    {
        /// <summary>
        /// Registers the repositories.
        /// </summary>
        /// <param name="service">The service collection.</param>
		public static void RegisterRepositories(this IServiceCollection service)
        {
            service.AddScoped<IEventRepository, EventRepository>();
            service.AddScoped<IPersonRepository, PersonRepository>();
            service.AddScoped<IEventAndPersonRepository, EventAndPersonRepository>();
            service.AddScoped<ICommentRepository, CommentRepository>();
            service.AddScoped<IAccountRepository, AccountRepository>();
            service.AddScoped<IEventUnitOfWork, EventUnitOfWork>();
            
        }
    }
}
