using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PocErrorHandling
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Force ENV to PROD for the POC
            env.EnvironmentName = EnvironmentName.Production;

            //First we configure the error handler middleware!
            //We enable the global error handler in others environment that DEV because debug page are useful during implementation
            //See https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-2.1 for technical details about Environment configuration
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //Our global handler is defined on "/api/error" URL so we indicate to the exception handler to call this API controller 
                //on any unexpected exception raised by the application
                app.UseExceptionHandler("/api/error");
            }

            //We configure others middleware, remember that the declaration order is important...
            app.UseMvc();
        }
    }
}
