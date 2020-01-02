using Microsoft.EntityFrameworkCore;
using myrestapi.Models;

namespace myrestapi.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>().ToTable("Books");
            builder.Entity<Book>().HasKey(p => p.Id);
            builder.Entity<Book>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Book>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Book>().Property(p => p.Genre).IsRequired().HasMaxLength(30);

        }
    }
}
