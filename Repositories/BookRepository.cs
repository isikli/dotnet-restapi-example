using System;
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
        public async Task<Book> AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> GetAsync(long id)
        {
            var book = await _context.Books.FindAsync (id);
            return book;
        }
        public async Task DeleteAsync (Book book)
        {
            _context.Books.Remove (book);
            await _context.SaveChangesAsync();
        }
    }
}

