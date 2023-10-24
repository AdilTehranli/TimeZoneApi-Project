using Microsoft.AspNetCore.Mvc;
using TimeZone.Business.Dtos.BrandDtos;
using TimeZone.Business.Dtos.ProductDtos;
using TimeZone.Business.Services.Implements;
using TimeZone.Business.Services.Interfaces;

namespace TimeZoneApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsController : ControllerBase
{
    readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpGet]
    public async Task<IActionResult> GetProduct()
    {
            return Ok(await _productService.GetAllAsync());

    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromForm] ProductCreateDto dto)
    {
      
            await _productService.CreateAsnyc(dto);
        return StatusCode(StatusCodes.Status201Created);


    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
    
            await _productService.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent);

        }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromForm] ProductUpdateDto updateDto)
    {
            await _productService.UpdateAsnyc(id, updateDto);
            return StatusCode(StatusCodes.Status204NoContent);

        }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductDetail(int id)
    {
       
            return Ok(await _productService.GetById(id));
    }
}
