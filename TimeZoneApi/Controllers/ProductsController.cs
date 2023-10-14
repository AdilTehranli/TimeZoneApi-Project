using Microsoft.AspNetCore.Mvc;
using TimeZone.Business.Dtos.BrandDtos;
using TimeZone.Business.Dtos.ProductDtos;
using TimeZone.Business.Services.Implements;
using TimeZone.Business.Services.Interfaces;

namespace TimeZoneApi.Controllers;

[Route("api/[controller]")]
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
        try
        {

            return Ok(await _productService.GetAllAsync());
        }
        catch (Exception)
        {

            throw new ArgumentException("Data getirile bilmedi");
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromForm] ProductCreateDto dto)
    {
        try
        {

            await _productService.CreateAsnyc(dto);
        }
        catch (Exception)
        {

            throw new ArgumentException("Yaradila bilmedi");
        }
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            await _productService.Delete(id);

        }
        catch (Exception)
        {

            throw new ArgumentException("Siline bilmedi");
        }
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromForm] ProductUpdateDto updateDto)
    {
        try
        {

            await _productService.UpdateAsnyc(id, updateDto);
        }
        catch (Exception)
        {

            throw new ArgumentException("Deyisdirile bilmedi");
        }
        return Ok();
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductDetail(int id)
    {
        try
        {
            return Ok(await _productService.GetById(id));
        }
        catch (Exception)
        {

            throw new ArgumentException("Product id gelmedi");
        }
    }
}
