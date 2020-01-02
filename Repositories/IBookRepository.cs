using System.Collections.Generic;
using System.Threading.Tasks;
using myrestapi.Models;

namespace myrestapi.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> ListAsync();
        Task<Book>  AddAsync(Book book);
        Task<Book> GetAsync(long id);
        Task DeleteAsync(Book book);
    }
}
