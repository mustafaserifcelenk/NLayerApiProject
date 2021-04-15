using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerApiProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApiProject.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        // Bu class category'e bağlı olduğu için constructor'da category id'leri almamız gerekiyor ki bağlantılar tanımlanabilsin   
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, ProductName = "Pilot Kalem", Price = 12.50m, Stock = 100, CategoryId = _ids[0] },
                new Product { Id = 2, ProductName = "Kurşun Kalem", Price = 10.50m, Stock = 200, CategoryId = _ids[0] },
                new Product { Id = 3, ProductName = "Tükenmez Kalem", Price = 9.50m, Stock = 300, CategoryId = _ids[0] },
                new Product { Id = 4, ProductName = "Küçük Boy Defter", Price = 15.50m, Stock = 150, CategoryId = _ids[1] },
                new Product { Id = 5, ProductName = "Orta Boy Defter", Price = 17.50m, Stock = 120, CategoryId = _ids[1] },
                new Product { Id = 6, ProductName = "Büyük Boy Defter", Price = 20.50m, Stock = 100, CategoryId = _ids[1] }
                );
        }
    }
}
