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

            var result = await _bookService.SaveAsync(book);

            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Book);
        }
    }
}