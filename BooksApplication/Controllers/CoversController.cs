using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BooksApplication.data.Mongo;
using BooksApplication.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BooksApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoversController : Controller
    {
        private readonly ICoversRepository _repo;

        public CoversController(ICoversRepository coversRepository)
        {
            _repo = coversRepository;
        }

        [HttpGet("{Id}")]
        public IActionResult Get(string Id)
        {
            ObjectId objectId = new ObjectId(Id);
            return Ok(_repo.Download(objectId));
        }

        [HttpPost]
        public IActionResult Post(IFormFile file)
        {
            if (file != null && file.ContentType.Contains("image"))
            {
                string Id = _repo.Upload(file);
                if (Id != null && !"".Equals(Id)) return Created("/api/covers/{Id}", Json(Id));
            }
            return BadRequest();
        }

    }
}