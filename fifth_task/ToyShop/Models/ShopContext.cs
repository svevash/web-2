using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToyShop.Models
{
    public class ShopContext : DbContext
    {
        public DbSet<Toy> Toys { get; set; }
        public DbSet<ToyType> Types { get; set; }
        public ShopContext(DbContextOptions options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}