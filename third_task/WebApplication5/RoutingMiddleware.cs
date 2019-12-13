using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication5
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;
        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
 
        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value.ToLower();
            switch (path)
            {
                case "/first":
                {
                    var a = 8;
                    var b = 5;
                    var c = 1;
            
                    for (var i = 0; i < b; i++)
                    {
                        c *= a - i;
                    }

                    await context.Response.WriteAsync($"a! / (a - b)! = {c}");
                    break;
                }
                case "/second":
                {
                    var a = 5;
                    var b = 8;

                    var res = Math.Sin(a) * Math.Cos(b) + Math.Cos(a) * Math.Sin(b);
                
                    await context.Response.WriteAsync( $"sin(a) * cos(b) + cos(a) * sin(b) = {res}");
                    break;
                }
                default:
                    context.Response.StatusCode = 404;
                    break;
            }
        }
    }
}