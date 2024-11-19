using book.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.bookrepo;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook context;
        public BookController(IBook db)
        {
            context = db;
        }
        [HttpGet("all")]
        public IActionResult Getall()
        {
            return Ok(context.getall());
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var x = context.get(id);
            if(x == null)
            {
                return BadRequest("bad");
            }
            return Ok(x);
        }
        [HttpPost]
        public IActionResult post(BookDTO1 dTO1)
        {
            context.add(dTO1);
            return Ok();
        }
        [HttpPut]
        public IActionResult update(BookDTO1 dTO1,int id)
        {
            context.update(dTO1,id);
            return Ok();
        }
        [HttpDelete]
        public IActionResult delete(int id)
        {
            context.remove(id);
            return Ok();
        }
    }
}
