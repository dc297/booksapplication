using BooksApplication.data.Redis;
using BooksApplication.Providers;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace BooksApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        IDatabase _redisDB;

        public StatsController(RedisClientProvider redisClientProvider)
        {
            _redisDB = redisClientProvider.redisClient.GetDatabase();
        }

        // GET api/authors
        [HttpGet]
        public Statistics Get()
        {
            return new Statistics
            {
                IpRequestCount = _redisDB.StringGet("ip:" + Request.HttpContext.Connection.RemoteIpAddress),
                AuthorCount = _redisDB.StringGet("author"),
                BookCount = _redisDB.StringGet("book")
            };
        }
    }
}