using Microsoft.AspNetCore.Http;

namespace TimeZone.Business.Dtos.ProductDtos;

public class ProductUpdateDto
{
    public IFormFile ProductImage { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public int BrandId { get; set; }
}
