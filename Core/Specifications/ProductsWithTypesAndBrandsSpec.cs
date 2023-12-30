using System.Linq.Expressions;
using Core.Entities;
using Core.Specification;
using System;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpec : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpec(string sort,int? brandId, int? typeId):
        base(x=>  (!brandId.HasValue || x.ProductBrandId ==brandId) &&
                  (!typeId.HasValue || x.ProductTypeId ==typeId))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);

            if(!string.IsNullOrEmpty(sort))
            {
              switch(sort)
              {
                case "priceAsc": AddOrderBy(p=> p.Price);
                break;
                case "priceDesc": AddOrderByDesc(p=> p.Price);
                break;
                default: AddOrderBy(n=>n.Name);
                break;
              }
            }
        }
        public ProductsWithTypesAndBrandsSpec(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}