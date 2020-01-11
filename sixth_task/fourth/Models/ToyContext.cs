using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fourth.Models
{
    public class ToyContext : DbContext
    {
        public DbSet<Toy> Toys { get; set; }
        public DbSet<ToyType> Types { get; set; }

        public ToyContext(DbContextOptions<ToyContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=shoptoydb;Trusted_Connection=True;");
    }
}
