using BookStoreApplicaion.Books.Entity.QueryEntity;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApplicaion.Books
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {

        }


        public DbSet<BookEntity> Books { get; set; }
    }
}
