using System;
using System.Collections.Generic;
using BooksApplication.data.Postgres;
using BooksApplication.data.Elastic;
using BooksApplication.Providers;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace authorsApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorsRepository _repository;
        private readonly IElasticRepository _elasticRepository;
        private readonly IDatabase _redisDB;

        public AuthorController(IAuthorsRepository authorsRepository, IElasticRepository elasticRepository, RedisClientProvider redisProvider)
        {
            _repository = authorsRepository;
            _elasticRepository = elasticRepository;
            _redisDB = redisProvider.redisClient.GetDatabase();
        }

        // GET api/authors
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _repository.GetAllAuthors();
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return _repository.GetAuthorById(id);
        }

        // POST api/authors
        [HttpPost]
        public IActionResult Post([FromBody] Author value)
        {
            _repository.AddAuthorWithBook(value);
            if (_repository.Save())
            {
                _elasticRepository.AddAuthorWithBook(value);
                _redisDB.StringIncrement("book");
                if (value.modified) return Accepted($"/api/author/{value.Id}", value);
                _redisDB.StringIncrement("author");
                return Created($"/api/author/{value.Id}",value);
            }
            return BadRequest(ModelState);
        }

        // PUT api/authors/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/authors/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
