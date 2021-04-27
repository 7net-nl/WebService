using AutoMapper;
using WebService.Domain.Entities;
using WebService.Service.ApplicationService.Images.Command.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebService.Service.ApplicationService.Products.Command.Create
{
    public class CreateProductProfile : Profile
    {
        public CreateProductProfile()
        {


          
            CreateMap<CreateImageRequest, Image>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Path)).ReverseMap();

            CreateMap<string, Category>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src=>src));

            CreateMap<string,Tag>()
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src=>src));

            CreateMap<string, Domain.Entities.Service>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src=>src));

            CreateMap<CreateProductRequest, Product>().ReverseMap();

            CreateMap<Tag, string>()
                 .ConvertUsing(c => c.Name);
            CreateMap<Domain.Entities.Service, string>()
                 .ConvertUsing(c => c.Name);
            CreateMap<Category, string>()
                 .ConvertUsing(c => c.Name);




        }
    }
}
