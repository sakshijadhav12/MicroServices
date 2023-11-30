using BookStoreAppliacation.Admin.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAppliacation.Admin.Dbcontext
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {

        }
        //public DbSet<AdminEntity> Books { get; set; }
        public DbSet<BookStoreAdminEntity> Admin { get; set; }

    }
}
