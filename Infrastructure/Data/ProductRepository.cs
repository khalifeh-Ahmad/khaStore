
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _cntxt;
        public ProductRepository(StoreContext cntxt)
        {
            _cntxt = cntxt;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _cntxt.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _cntxt.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductType)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            // var typeId = 1;
            // var porducts=_cntxt.Products.Where( x=> x.ProductTypeId == typeId )
            // .Include(x=>x.ProductType)
            // .ToListAsync();

            return await _cntxt.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .ToListAsync();

        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _cntxt.ProductTypes.ToListAsync();
        }
    }
}