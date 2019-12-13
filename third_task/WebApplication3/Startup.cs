using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication3
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.Map("/first", First);
            app.Map("/second", Second);
 
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("go to /first or /second");
            });
        }
 
        private static void First(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var a = 8;
                var b = 5;

                var c = 1;
                for (var i = 0; i < b; i++)
                {
                    c *= a - i;
                }
                
                await context.Response.WriteAsync($"a! / (a - b)! = {c}");
            });
        }
        private static void Second(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var a = 5;
                var b = 8;

                var res = Math.Sin(a) * Math.Cos(b) + Math.Cos(a) * Math.Sin(b);
                
                await context.Response.WriteAsync( $"sin(a) * cos(b) + cos(a) * sin(b) = {res}");
            });
        }
    }
}