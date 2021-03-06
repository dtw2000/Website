﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication3.Models;
using Microsoft.Extensions.Configuration;

namespace WebApplication3
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;
        
        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddJsonFile($"config.development.json", optional: true);
            _config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);
            services.AddMvc();
            services.AddScoped<ICommentRepository,CommentRepository>();
            services.AddDbContext<WebsiteDBContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
            }

           // app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(config =>
            {

                config.MapRoute(
                     name: "index",
                     template: "",
                     defaults: new { controller = "App", action = "Index" }
                     );

                config.MapRoute(
                    name: "apiComments",
                    template: "api/comments/{id?}",
                    defaults: new { controller = "Comments", action = "ApiComments" }
                    );

                config.MapRoute(
                    name: "comments",
                    template: "comments/{id?}",
                    defaults: new { controller = "App", action = "Comments" }
                    );

                config.MapRoute(
                    name: "contact",
                    template: "contact/{id?}",
                    defaults: new { controller = "App", action = "Contact" }
                    );

                config.MapRoute(
                    name: "resume",
                    template: "resume/{id?}",
                    defaults: new { controller = "App", action = "Resume" }
                    );

                config.MapRoute(
                    name: "thanks",
                    template: "thanks/{id?}",
                    defaults: new { controller = "App", action = "Thanks" }
                    );

                config.MapRoute(
                    name: "Default",
                    //template: "{controller}/{action}/{id?}",
                    //defaults: new { controller = "App", action = "Index" }
                    template: "{id?}",
                    defaults: new { controller = "App", action = "Redirect" }
                    );
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("<html><body><h1>Hello World!</h1></body></html>");
            //});
        }
    }
}
