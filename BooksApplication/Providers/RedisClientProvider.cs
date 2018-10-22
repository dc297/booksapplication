using BooksApplication.Settings;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace BooksApplication.Providers
{
    public class RedisClientProvider
    {
        public readonly ConnectionMultiplexer redisClient;

        public RedisClientProvider(IOptions<RedisConnectionSettings> settings)
        {
            redisClient = ConnectionMultiplexer.Connect(settings.Value.Url);
        }
    }
}
