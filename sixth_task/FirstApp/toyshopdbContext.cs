using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FirstApp
{
    public partial class toyshopdbContext : DbContext
    {
        public toyshopdbContext()
        {
        }

        public toyshopdbContext(DbContextOptions<toyshopdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ToyTypes> ToyTypes { get; set; }
        public virtual DbSet<Toys> Toys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=toyshopdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Toys>(entity =>
            {
                entity.HasIndex(e => e.TypeId);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Toys)
                    .HasForeignKey(d => d.TypeId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
