namespace eShop.Services.Image.API.Models;

public class Image
{
    public Guid Id { get; set; }
    public Metadata Metadata { get; set; }
    public byte[] Data { get; set; }
}