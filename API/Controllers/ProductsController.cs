using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;


namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController:ControllerBase
  {

    private readonly IGenericRepository<Product> _productRepo;
    private readonly IGenericRepository<ProductBrand> _productBrandRepo;
    private readonly IGenericRepository<ProductType> _productTypeRepo;
    public ProductsController(IGenericRepository<Product> productsRepo,
    IGenericRepository<ProductBrand> productBrandRepo,IGenericRepository<ProductType> productTypeRepo)
    {
      _productRepo = productsRepo;
      _productBrandRepo = productBrandRepo;
      _productTypeRepo = productTypeRepo;

    }
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
      var spec= new ProductsWithTypesAndBrandsSpec();
      var prdcts = await _productRepo.ListAsync(spec);

      return Ok(prdcts);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
      var spec= new ProductsWithTypesAndBrandsSpec(id);
      return await _productRepo.GetEntityWithSpec(spec);
    }
    [HttpGet("brands")]
    public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
    {
    
      return Ok(await _productBrandRepo.ListAllAsync());
    }

    [HttpGet("types")]
    public async Task<ActionResult<List<ProductType>>> GetProductTypes()
    {
      return Ok(await _productTypeRepo.ListAllAsync());
    }

  }
}