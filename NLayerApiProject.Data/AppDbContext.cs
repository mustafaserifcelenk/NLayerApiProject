using Microsoft.EntityFrameworkCore;
using NLayerApiProject.Core.Models;
using NLayerApiProject.Data.Configuration;
using NLayerApiProject.Data.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApiProject.Data
{
    public class AppDbContext : DbContext
    {
        // Options seçeneği ne kullanılacağını belirtiyor(sqlserver, postgre vs.)
        // Api veya Web'in startup'ında bu option doldurulacak
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));

        }

    }
}
