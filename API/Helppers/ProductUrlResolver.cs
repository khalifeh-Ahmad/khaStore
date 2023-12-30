using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helppers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {

        private readonly IConfiguration _conf;
        public ProductUrlResolver(IConfiguration conf)
        {
            _conf = conf;
        }
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImgUrl))
            {
                return _conf["ApiUrl"] + source.ImgUrl;
            }
            return null;
        }
    }
}