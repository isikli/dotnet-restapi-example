using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myrestapi.Models;
using myrestapi.Persistence;

namespace myrestapi.Repositories
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> ListAsync()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

    }
}

