using AutoMapper;
using FirstAPI.DataAccess.Entity;
using FirstAPI.Services.Models;

namespace FirstAPI.Services.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Task<Product>, Product>().ReverseMap();
        }
        
    }
}
