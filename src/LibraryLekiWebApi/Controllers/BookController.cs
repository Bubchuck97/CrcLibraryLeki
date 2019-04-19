using LibraryLekiWebApi.Models;
using LibraryLekiWebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryLekiWebApi.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository<Book> _bookRepository;

        public BookController(IBookRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookRepository.GetAll();

            return Ok(books);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(uint id)
        {
            var book = await _bookRepository.Get(id);

            if (book == null)
            {
                return NotFound("The book record not found. :(");
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            if (book == null)
            {
                return BadRequest("The book is null!!!");
            }

            await _bookRepository.Add(book);

            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(uint id, Book book)
        {
            var bookToUpdate = await _bookRepository.Get(id);

            if (bookToUpdate == null)
            {
                return NotFound("The book record to update couldnt be found.");
            }

            await _bookRepository.Update(bookToUpdate, book);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(uint id)
        {
            var bookToDelete = await _bookRepository.Get(id);

            if (bookToDelete == null)
            {
                return NotFound("The book to delete couldnt be found.");
            }

            await _bookRepository.Delete(bookToDelete);

            return NoContent();
        }

    }
}
