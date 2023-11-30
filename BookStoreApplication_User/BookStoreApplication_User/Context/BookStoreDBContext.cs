using BookStoreApplication_User.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApplication_User.Context
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options)
        {
            
        }

        public DbSet<UserEntity> User { get; set; }
    }
}
