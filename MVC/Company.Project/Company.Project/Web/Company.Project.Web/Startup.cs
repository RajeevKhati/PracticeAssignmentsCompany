using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Company.Project.Core.ExceptionManagement;
using Company.Project.EventDomain.AppServices;
using Company.Project.EventDomain.AppServices.Mapper;
using Company.Project.EventDomain.Configuration;
using Company.Project.EventDomain.Data.DBContext;
using Company.Project.EventDomain.Domain;
using Company.Project.EventFacade.FacadeFactory;
using Company.Project.Web.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;

namespace Company.Project.Web
{
    public class Startup
    {
        private MapperConfiguration _mapperConfiguration { get; set; }
        private IExceptionManager exceptionManager;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
                cfg.AddProfile(new WebMappingProfile());
            });

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            Company.Project.Core.Logging.ILogger logger = Company.Project.Loggig.NLog.Logger.GetLoggerInstance;
            exceptionManager = new ExceptionManager(logger);
          
            services.RegisterRepositories();
            services.AddScoped<IMapper>(sp => _mapperConfiguration.CreateMapper());
            services.AddScoped<IEventAppService, EventAppService>();
            services.AddScoped<IEventFacadeFactory, EventFacadeFactory>();
            services.AddScoped<IExceptionManager, ExceptionManager>();
            //services.AddSingleton<Company.Project.Core.Logging.ILogger, Company.Project.Loggig.NLog.Logger>();
            services.AddSingleton<Company.Project.Core.Logging.ILogger>(Company.Project.Loggig.NLog.Logger.GetLoggerInstance);
            services.AddDbContext<EventDomainDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<EventDomainDbContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
