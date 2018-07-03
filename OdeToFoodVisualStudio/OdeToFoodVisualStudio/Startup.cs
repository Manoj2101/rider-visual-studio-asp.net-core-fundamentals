﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OdeToFoodVisualStudio
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                // Configuration sources by descending priority: 1. command-line parameter, 2. environment variable, 3. appsettings.json (enables storing dev settings in appsettings.json and overriding them in production wtih environment variables for example)

                // VsvsRider: doesn look like there's an action to add a new comment (there are actions to comment/decomment existing code; and to add documentation comment)
                // VsvsRider: VS create from usage isn't quite on par right now: given the undeclared IGreeter interface in method parameteres and the below line that uses an undeclared method,
                // <strike>1. You must create the interface from usage first, and only then can you create the method - so there's no chaining in Create from Usage;</strike> - same in Rider :(
                // 2. The created symbol doesn't get focus: both when it's created in a separate file and when it's created in the same file
                // 3. Roslyn doesn't infer that the generated method should return a string, not an object

                var greeting = greeter.GetMessageOfTheDay();

                await context.Response.WriteAsync(greeting);
            });
        }
    }
   
}
