using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NbClassifier.Web.DAL.Entities;

namespace NbClassifier.Web.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReviewCategory>()
                .HasKey(_ => new { _.ReviewId, _.CategoryId });

            modelBuilder.Entity<ReviewCategory>()
                .HasOne(_ => _.Review)
                .WithMany(_ => _.ReviewCategories)
                .HasForeignKey(_ => _.ReviewId);

            modelBuilder.Entity<ReviewCategory>()
                .HasOne(_ => _.Category)
                .WithMany(_ => _.ReviewCategories)
                .HasForeignKey(_ => _.CategoryId);
        }
    }
}
