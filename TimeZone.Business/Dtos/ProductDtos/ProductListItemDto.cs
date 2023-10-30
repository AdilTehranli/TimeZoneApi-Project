using Microsoft.AspNetCore.Http;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Dtos.ProductDtos;

public class ProductListItemDto
{
    public int Id { get; set; }
    public string ProductImage { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
}
