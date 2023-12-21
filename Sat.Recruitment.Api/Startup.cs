using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sat.Recruitment.Application.Interface;
using Sat.Recruitment.Domain.Interface;
using Sat.Recruitment.Domain.Core;
using Sat.Recruitment.Domain.Entity;
using Sat.Recruitment.Application.Main;
using Sat.Recruitment.Infrastructure.Interface;
using Sat.Recruitment.Infrastructure.Repository;
using Sat.Recruitment.Transversal.Common;
using Sat.Recruitment.Infrastructure.Data;
using Sat.Recruitment.Transversal.Mapper;
using Sat.Recruitment.Transversal.Common.Exceptions;

using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using Microsoft.Identity.Client;
using Sat.Recruitment.Transversal.Common.Filters;


namespace Sat.Recruitment.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers( opc =>
            {
                opc.Filters.Add<FilterCustomException>(); 
            });
            services.AddSwaggerGen( config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "API WSVAP (WebSmartView)", Version = "v1" });
                config.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<IDBConnectionFactory,ConnectionFactory>();
            services.AddAutoMapper( x => x.AddProfile(new MapperProfile()));

            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddSingleton<IUserOperationsDomain,UserOperationsDomain>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            // app.UseSwaggerUI();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
