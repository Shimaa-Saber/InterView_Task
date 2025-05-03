using AutoMapper;
using InterView_Task.DTOs.Product;
using InterView_Task.Models;

namespace InterView_Task.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile() {
            CreateMap<Product, AddProductDto>();
            CreateMap<AddProductDto, Product>();
            CreateMap<EditProductDto, Product>();
            CreateMap<Product, EditProductDto>();
        }
    }
    }

