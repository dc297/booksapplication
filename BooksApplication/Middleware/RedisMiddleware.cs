using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApplication.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace BooksApplication.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RedisMiddleware
    {
        private readonly RequestDelegate _next;
        IDatabase _redisDB;


        public RedisMiddleware(RequestDelegate next, RedisClientProvider provider)
        {
            _next = next;
            _redisDB = provider.redisClient.GetDatabase();
        }

        public Task Invoke(HttpContext httpContext)
        {
            string remoteIP = httpContext.Connection.RemoteIpAddress.ToString();
            _redisDB.StringIncrement("ip:"+remoteIP);
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RedisMiddleware>();
        }
    }
}
