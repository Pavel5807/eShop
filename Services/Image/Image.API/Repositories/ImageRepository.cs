using Microsoft.Extensions.Options;
using MongoDB.Driver;
using eShop.Services.Image.API.Settings;

namespace eShop.Services.Image.API.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly IMongoCollection<Models.Image> _collection;

    public ImageRepository(IOptions<DatabaseSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<Models.Image>(settings.Value.CollectionName);
    }

    public async Task<Models.Image?> GetAsync(Guid id)
    {
        return await _collection.Find(image => image.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Models.Image image)
    {
        await _collection.InsertOneAsync(image);
    }

    public async Task RemoveAsync(Guid id)
    {
        await _collection.DeleteOneAsync(image => image.Id == id);
    }
}