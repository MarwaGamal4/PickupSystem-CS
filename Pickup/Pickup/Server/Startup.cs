using Hangfire;
using Hangfire.Dashboard;
using Hangfire.Dashboard.BasicAuthorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Pickup.Application.Extensions;
using Pickup.Client.Infrastructure.Settings;
using Pickup.Infrastructure.Extensions;
using Pickup.Server.Extensions;
using Pickup.Server.Middlewares;
using Pickup.Shared.Settings;
using System.IO;


namespace Pickup.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPreference, ClientPreference>();
            services.AddSignalR();
            services.AddDatabase(_configuration);
            services.AddIdentity();
            services.AddJwtAuthentication(services.GetApplicationSettings(_configuration));
            //TODO - add CustomServerLocalStorageService
            //services.AddScoped<ILocalStorageService, CustomServerLocalStorageService>();
            //services.AddScoped<IServerPreferenceManager, ServerPreferenceManager>();
            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });
            services.AddApplicationLayer();
            services.AddApplicationServices();
            services.AddSharedInfrastructure(_configuration);
            services.RegisterSwagger();

            services.AddInfrastructureMappings();
            services.AddHangfire(x => x.UseSqlServerStorage(_configuration.GetConnectionString("DefaultConnection")));
            services.AddHangfireServer();
            services.AddControllers().AddValidators();
            services.AddRazorPages();
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
            services.AddLazyCache();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var options = new DashboardOptions()
            {
                Authorization = new IDashboardAuthorizationFilter[]
    {
        new BasicAuthAuthorizationFilter(
            new BasicAuthAuthorizationFilterOptions
            {
                // Case sensitive login checking
                LoginCaseSensitive = true,
                // Users
                Users = new[]
                {
                    new BasicAuthAuthorizationUser()
                    {
                        Login = "Admin",
                        // Password as plain text, SHA1 will be used
                        PasswordClear = "Admin"
                    }
                }
            })
    }
            };
            app.UseExceptionHandling(env);
            app.UseHttpsRedirection();

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Files")),
                RequestPath = new PathString("/Files")
            });
            app.UseRequestLocalizationByCulture();
            app.UseRouting();
            app.UseAuthentication();
            app.UseHangfireDashboard("/jobs", options);
            app.UseAuthorization();
            app.UseEndpoints();
            app.ConfigureSwagger();
            app.Initialize(_configuration);
        }
    }
}