using System.Collections.Generic;
using System.Threading.Tasks;
using myrestapi.Models;
using myrestapi.Repositories;

namespace myrestapi.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> ListAsync();
        Task<BookResponse> DeleteAsync(long id);
        Task<BookResponse> AddAsync(Book book);

        Task<Book> GetAsync(long id);

    }
}
