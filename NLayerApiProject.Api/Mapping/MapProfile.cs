using AutoMapper;
using NLayerApiProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLayerApiProject.API.DTOs;

namespace NLayerApiProject.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // Category'i CategoryDto'ya dönüştür
            CreateMap<Category, CategoryDto>().ReverseMap();
            //CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryWithProductDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Product, ProductWithCategoryDto>();

            CreateMap<ProductWithCategoryDto, Product>();
        }
    }
}