﻿using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PepperApp.Data;
using PepperApp.Logger;
using PepperApp.Repositories;
using PepperApp.Services;

namespace PepperApp.API
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
            services.AddDbContext<PepperContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("LibraryConnectionString")));

            // Explicitly registers repository class  
            services.AddScoped<PepperRepository>();
            services.AddScoped<IPepperRepository, PepperRepository>();

            services.AddScoped<IPepperService, PepperService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton<PepperAppLogger>();

            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PepperApp.API", Version = "v1" });
            });

            // Retrieve the connection string from the configuration
            string? connectionString = Configuration.GetConnectionString("LibraryConnectionString");

            // Log the connection string to the console
            Console.WriteLine("Connection string: {0}", connectionString);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            PepperAppLogger.StartLogger();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PepperApp.API");
            });
        }
    }
}
