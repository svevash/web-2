using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication4
{
    public class NewMiddleware
    {
        private readonly RequestDelegate _next;
 
        public NewMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
 
        public async Task InvokeAsync(HttpContext context)
        {
            var a = 8;
            var b = 5;
            var c = 1;
            
            for (var i = 0; i < b; i++)
            {
                c *= a - i;
            }

            await context.Response.WriteAsync($"a! / (a - b)! = {c}");
            await _next.Invoke(context);
        }
    }
}