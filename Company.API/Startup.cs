using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autofac;

namespace Company.API
{
    public class Startup
    {
        readonly IWebHostEnvironment env;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallServicesFromAssembly(Configuration, env);
        }

        // Register your own things directly with Autofac here.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<DomainModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                SwaggerOptions swagger = Configuration.GetSection(nameof(SwaggerOptions)).Get<SwaggerOptions>();
                app.UseSwagger(options => options.RouteTemplate = swagger.JsonRoute);
                app.UseSwaggerUI(c => c.SwaggerEndpoint(swagger.UIEndpoint, swagger.Description));
            }
            app.UseRouting();
            app.UseCors(CommonValues.AllowOrigins);
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
