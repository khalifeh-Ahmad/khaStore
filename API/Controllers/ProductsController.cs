using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using API.Dtos;
using AutoMapper;


namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController:ControllerBase
  {

    private readonly IGenericRepository<Product> _productRepo;
    private readonly IGenericRepository<ProductBrand> _productBrandRepo;
    private readonly IGenericRepository<ProductType> _productTypeRepo;
    private readonly IMapper _mapper;
    public ProductsController(IGenericRepository<Product> productsRepo,
    IGenericRepository<ProductBrand> productBrandRepo,IGenericRepository<ProductType> productTypeRepo,IMapper mapper)
    {
      _productRepo = productsRepo;
      _productBrandRepo = productBrandRepo;
      _productTypeRepo = productTypeRepo;
      _mapper=mapper;

    }
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
    {
      var spec= new ProductsWithTypesAndBrandsSpec();
      var prdcts = await _productRepo.ListAsync(spec);

      return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(prdcts));
      
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
    {
      var spec= new ProductsWithTypesAndBrandsSpec(id);
      var product= await _productRepo.GetEntityWithSpec(spec);
      return  _mapper.Map<Product, ProductToReturnDto>(product);
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