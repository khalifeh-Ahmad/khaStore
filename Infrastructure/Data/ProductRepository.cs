
using System.Collections.Generic;
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
    public async Task<Product> GetProductByIdAsync(int id)
    {
      return await _cntxt.Products.FindAsync(id);
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
      
      return await _cntxt.Products.ToListAsync();;
    }
  }
}