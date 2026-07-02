using Application.DTOs.Item;
using Application.DTOs.Product;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();

        CreateMap<CreateProductDto, Product>();

        CreateMap<UpdateProductDto, Product>();

        CreateMap<Item, ItemDto>().ReverseMap();

        CreateMap<CreateItemDto, Item>();

        CreateMap<UpdateItemDto, Item>();
    }
}