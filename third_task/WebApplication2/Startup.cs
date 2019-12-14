using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication2
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            var a = 8;
            var b = 5;
            var c = 1;
            app.Use(async (context, next) =>
            {
                for (var i = 0; i < b; i++)
                {
                    c *= a - i;
                }
                await next.Invoke();
            });
 
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"a! / (a - b)! = {c}");
                c = 1;
            });
        }
    }
}