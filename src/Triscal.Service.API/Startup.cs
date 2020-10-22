using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Triscal.Application.AutoMapper;
using Triscal.Infrastructure.Data.Context;
using Triscal.Infrastructure.IoC;

namespace Triscal.Service.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;            
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // ConnectionString

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            // Context

            services.AddDbContextPool<TriscalContext>(option =>
                 option.UseSqlServer(connectionString)
             );

            // Factory

            services.AddTransient<IDbConnection>(db =>
                new SqlConnection(connectionString)
            );

            // IoC

            InjectorDependency.Register(services);

            // AutoMapper

            services.AddAutoMapper(x => x.AddProfile(new Mapping()));

            // Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API Clientes",
                    Description = "API de Desafio para Desenvolvedor .NET da Triscal",
                    Version = "v1"
                });
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Swagger

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Clientes");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}