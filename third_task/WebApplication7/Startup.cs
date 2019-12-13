using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication7.Services;

namespace WebApplication7
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();
            Random rnd = new Random();
            var i  = rnd.Next(0, 2);
            services.AddTransient<IMessageSender>(provider=> {
                if (i != 0) return new EmailMessageSender();
                else return new SmsMessageSender();
            });
            services.AddTransient<MessageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MessageService messageService)
        {
            app.UseSession();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(messageService.Send(context));
                
                if (!context.Request.Cookies.ContainsKey("text"))
                { 
                    context.Response.Cookies.Append("text", "hello");
                }
                    
                if (!context.Session.Keys.Contains("text"))
                {
                    context.Session.SetString("text", "goodbye");
                }

            });
        }
    }
}