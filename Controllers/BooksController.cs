using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myrestapi.Models;
using myrestapi.Services;

namespace myrestapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public async Task<Book> GetAsync(int id)
        {
            Console.WriteLine("Get "+id);
            var books = await _bookService.GetAsync(id);
            return books;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            Console.WriteLine("Get");
            var books = await _bookService.ListAsync();
            return books;
        }

        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody] Book book)
        {
            Console.WriteLine("HttpPost");

            if (!ModelState.IsValid)
                return BadRequest(ModelState.ValidationState);

            var result = await _bookService.AddAsync(book);

            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Console.WriteLine("Delete " + id);
            var result = await _bookService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Book);
        }
    }
}