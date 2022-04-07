using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AspWithHamed
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomeMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            var query = httpContext.Request.Query;
            if (query.TryGetValue("name", out var name))
            {
                httpContext.Response.WriteAsync($"Hello {name}");
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomeMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomeMiddleware>();
        }
    }
}
