namespace eShop.Services.Image.API.Repositories;

public interface IImageRepository
{
    Task CreateAsync(Models.Image image);
    Task<Models.Image?> GetAsync(Guid id);
    Task RemoveAsync(Guid id);
}
