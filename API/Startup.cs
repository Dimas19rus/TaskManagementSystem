using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Repository;
using Data;
using Data.Interfaces;
using Data.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
           

            var provider = services.BuildServiceProvider();
            var config = provider.GetRequiredService<IConfiguration>();
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRepository<MainTask>, MainTaskRepository>();
            services.AddScoped<IMainTaskService, MainTaskService>();

            services.AddMvc();
            //services.AddMvc()
            //    .AddDataAnnotationsLocalization(options => {
            //        options.DataAnnotationLocalizerProvider = (type, factory) =>
            //            factory.Create(typeof());
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            var supportedCultures = new[]
            {
                new CultureInfo("ru")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ru"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
