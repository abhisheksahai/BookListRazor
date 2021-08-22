using BookListRazor.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookListRazor.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _br;
        public BookController(IBookRepository br)
        {
            _br = br;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var booksFromDb = _br.GetBooks();
            return Ok(booksFromDb);
        }

        [HttpDelete]
        public IActionResult DeleteBook(int Id)
        {
            if (_br.DeleteBook(Id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
