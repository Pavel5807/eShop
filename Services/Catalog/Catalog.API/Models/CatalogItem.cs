namespace eShop.Services.Catalog.API.Models;

public class CatalogItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string[] ImageUrls { get; set; }
}