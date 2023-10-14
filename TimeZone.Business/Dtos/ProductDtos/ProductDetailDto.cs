using Microsoft.AspNetCore.Http;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Dtos.ProductDtos;

public class ProductDetailDto
{
    public int Id { get; set; }
    public string ProductImage { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public Category Category { get; set; }
    public Brand Brand { get; set; }
}
