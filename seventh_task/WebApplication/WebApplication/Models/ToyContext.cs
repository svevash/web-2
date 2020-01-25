using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class ToyContext : DbContext
    {
        public DbSet<Toy> Toys { get; set; }
        public ToyContext(DbContextOptions options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}