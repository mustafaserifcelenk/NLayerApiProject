﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerApiProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApiProject.Data.Seeds
{
    class CategorySeed : IEntityTypeConfiguration<Category>
    {
        // Bu class category'e bağlı olduğu için constructor'da category id'leri almamız gerekiyor ki bağlantılar tanımlanabilsin   
        private readonly int[] _ids;
        public CategorySeed(int[] ids)
        {
            _ids = ids;
        }


        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category { Id = _ids[0], Name = "Kalemler" },
                new Category { Id = _ids[1], Name = "Defterler" });
        }
    }
}