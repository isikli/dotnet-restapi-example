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

        public async Task<SaveBookResponse> SaveAsync(Book book)
        {
            try
            {
                await _bookRepository.AddAsync(book);
                return new SaveBookResponse(book);
            }
            catch (System.Exception ex)
            {
                return new SaveBookResponse($"An error occurred when saving the category: {ex.Message}");
            }

        }
    }
}