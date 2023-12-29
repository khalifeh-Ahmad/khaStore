using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helppers
{
  public class MappingProfiles:Profile
  {
      public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.ImgUrl, o => o.MapFrom<ProductUrlResolver>());
        }
  }
}