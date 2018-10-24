using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;

namespace BooksApplication.Providers
{
    public class RedisClientProvider
    {
        public readonly ConnectionMultiplexer redisClient;

        public RedisClientProvider()
        {
            redisClient = ConnectionMultiplexer.Connect(Environment.GetEnvironmentVariable("REDISCONNECTIONSTRING"));
        }
    }
}
