using BookManagemant.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagemant.Context
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {

        }

        public DbSet<BookModel> Books { get; set; }
    }
}
