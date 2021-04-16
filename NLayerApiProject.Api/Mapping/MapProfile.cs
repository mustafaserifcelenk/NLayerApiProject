using AutoMapper;
using NLayerApiProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.API.DTOs;

namespace UdemyNLayerProject.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // Category'i CategoryDto'ya dönüştür
            CreateMap<Category, CategoryDto>().ReverseMap();
            //CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryWithProductDto>();
            CreateMap<CategoryWithProductDto, Category>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Product, ProductWithCategoryDto>();

            CreateMap<ProductWithCategoryDto, Product>();
        }
    }
}