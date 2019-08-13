using AutoMapper;
using AutoMapper.Configuration;
using StockTrackAspNetCore.Database.EntityModels;
using StockTrackAspNetCore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockTrackAspNetCore.Models
{
    public class SimpleMappings : Profile
    {
        public SimpleMappings()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<WebCompanies, ProductDto>()
                .ForMember(d => d.CompanyName, a => a.MapFrom(s => s.CompanyName));
            

            // Mapper.CreateMap<People, PeoplePhoneDto>();
            // Mapper.CreateMap<Phone, PeoplePhoneDto>()
            //         .ForMember(d => d.PhoneNumber, a => a.MapFrom(s => s.Number));

            //Mapper.Initialize(cfg => cfg.CreateMap<OrderLine, OrderLineDTO>() 
            //.ForMember(dto => dto.Item, conf => conf.MapFrom(ol => ol.Item.Name)));
        }
        
    }

    public static class MapperExtensions
    {
        public static TDestination Map<TSource, TDestination>( this TDestination destination, TSource source)
        {
            //use 
            //var dto = Mapper.Map<ProductDto>(people)
              //  .Map(phone);

            return Mapper.Map(source, destination);
        }
    }
}
