using System.Threading.Tasks;
using BooksApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly SearchService _service;
        public BookController(SearchService searchService)
        {
            _service = searchService;
        }

        [HttpGet("search")]
        public async Task<JsonResult> Search([FromQuery]string query, int page = 1, int pageSize = 10)
        {
            var result = await _service.Search(query, page, pageSize);
            return Json(result);
        }

        [HttpGet("autocomplete")]
        public async Task<JsonResult> AutoComplete([FromQuery]string query, int page = 1, int pageSize = 10)
        {
            if(query!=null && !"".Equals(query)) {
                var result = await _service.Autocomplete(query);
                return Json(result);
            }
            return Json(BadRequest());
        }
    }
}