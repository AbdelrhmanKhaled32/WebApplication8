using book.Dtos;
using book.repoauthor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthor context;
        public AuthorController(IAuthor db)
        {
            context = db;
        }
        [HttpPost]
        public IActionResult post(AuthorDTO authorDTO)
        {
            context.addauthor(authorDTO);
            return Ok();
        }
        [HttpGet]
        public IActionResult get(int id)
        {
            var x = context.getauthor(id);
            if(x == null)
            {
                return BadRequest("aloo");
            }
            return Ok(x);
        }
        [HttpDelete]
        public IActionResult delete(int id)
        {
            context.remove(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult update(AuthorDTO authorDTO,int id)
        {
            context.Updateauthor(authorDTO,id);
            return Ok();
        }
        [HttpGet("all")]
        public IActionResult getall()
        {
            return Ok(context.getauthorall());
        }
    }
}
