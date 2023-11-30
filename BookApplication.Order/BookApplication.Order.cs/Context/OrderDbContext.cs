using BookApplication.Order.cs.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookApplication.Order.cs.Context
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public DbSet<OrderEntity> Orders { get; set; } 
    }
}
