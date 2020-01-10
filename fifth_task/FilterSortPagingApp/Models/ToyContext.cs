using Microsoft.EntityFrameworkCore;

namespace FilterSortPagingApp.Models
{
    public class ToyContext : DbContext
    {
        public DbSet<Toy> Toys { get; set; }
        public DbSet<ToyType> ToyTypes { get; set; }
        public ToyContext(DbContextOptions options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}