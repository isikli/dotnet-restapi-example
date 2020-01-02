using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace myrestapi.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }

        public static implicit operator Book(EntityEntry<Book> v)
        {
            throw new NotImplementedException();
        }
    }
}
