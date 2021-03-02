using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SearchEngine.Core;
using System;
using SearchEngine.Services.SearchEngineService;
using SearchEngine.API.Helpers;
using SearchEngine.API.Intefaces;
//using Microsoft.Extensions.Logging;
using SearchEngine.API.Extensions;
using System.IO;
using NLog;

namespace SearchEngine.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureLoggerService();
            services.AddControllers();
            services.AddTransient<ISearchEngineService, SearchKeywordService>();
            services.AddTransient<ISearchKeywordHelper, SearchKeywordHelper>();
            services.AddMemoryCache();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Search API",
                    Description = "A simple web API to call other API and sort data according to input paramater",
                    TermsOfService = new Uri("https://mukultermsandconditions.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Mukul Narad",
                        Email = "mukul.narad@gmail.com",
                        Url = new Uri("https://linkedin.com/mnarad"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under Open Licence",
                        Url = new Uri("https://myregistedlicence.com/license"),
                    }
                });
            });
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();
            app.ConfigureExceptionHandler(logger);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SearchEngine API");
            });
                

        }
    }
}
