using Microsoft.AspNetCore.Mvc;
using eShop.Services.Image.API.Repositories;

namespace eShop.Services.Image.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ImageController : ControllerBase
{
    private readonly IImageRepository _repository;

    public ImageController(IImageRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var image = await _repository.GetAsync(id);

        if (image is null)
        {
            return NotFound();
        }

        var fileContents = image.Data;
        var contetnType = GetImageMimeTypeFromImageFileExtension(image.Metadata.Extension);

        return File(fileContents, contetnType);
    }

    private string GetImageMimeTypeFromImageFileExtension(string extension) => extension switch
    {
        "bmp" => "image/bmp",
        "gif" => "image/gif",
        "jp2" => "image/jp2",
        "jpeg" => "image/jpeg",
        "jpg" => "image/jpeg",
        "png" => "image/png",
        "svg" => "image/svg+xml",
        "tiff" => "image/tiff",
        "wmf" => "image/wmf",
        _ => "application/octet-stream",
    };
}