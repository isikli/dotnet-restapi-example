using System.Collections.Generic;
using System.Threading.Tasks;
using myrestapi.Models;

namespace myrestapi.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> ListAsync();
        Task AddAsync(Book book);
    }
}
