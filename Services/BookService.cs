using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using myrestapi.Models;
using myrestapi.Repositories;

namespace myrestapi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> ListAsync()
        {
            return await _bookRepository.ListAsync();
        }

        public async Task<Book> GetAsync(long id)
        {
            return await _bookRepository.GetAsync(id);
        }

        public async Task<BookResponse> DeleteAsync (long id)
        {
            var existingBook = await _bookRepository.GetAsync(id);

            if (existingBook == null)
                return new BookResponse("Book not found.");

            try
            {
                await _bookRepository.DeleteAsync (existingBook);

                return new BookResponse(existingBook);
            }
            catch (System.Exception ex)
            {
                // Do some logging stuff
                return new BookResponse($"An error occurred when deleting the book: {ex.Message}");
            }

        }

        public async Task<BookResponse> AddAsync(Book book)
        {
            try
            {
                Book createdBook = await _bookRepository.AddAsync(book);
                return new BookResponse(createdBook);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new BookResponse($"An error occurred when saving the book: {ex.Message}");
            }

        }
    }
}