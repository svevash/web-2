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

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}