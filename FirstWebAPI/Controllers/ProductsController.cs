using FirstWebAPI.Model;
using FirstWebAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public ProductsController(IBookRepository repository)
        {
            _bookRepository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                return Ok(await _bookRepository.GetAllBookAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookAsync(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddNewBook(BookModel model)
        {
            try
            {
                var newBook = await _bookRepository.AddBookAsync(model);
                var book = await _bookRepository.GetBookAsync(newBook);
                return book == null ? NotFound() : Ok(book);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateBook(int id, BookModel model)
        {
            try
            {
                if (id != model.Id)
                {
                    return NotFound();
                }
                await _bookRepository.UpdateBookAsync(id, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                int statusDelete = await _bookRepository.DeleteBookAsync(id);
                if (statusDelete == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
