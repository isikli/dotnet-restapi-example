using System.Collections.Generic;
using System.Threading.Tasks;
using myrestapi.Models;
using myrestapi.Repositories;

namespace myrestapi.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> ListAsync();
        Task<SaveBookResponse> SaveAsync(Book book);
    }
}
