using Grpc.Core;
using eShop.Services.Image.API.Models;
using eShop.Services.Image.API.Repositories;

namespace GrpcImage;

public class ImageService : ImageRepositoryManager.ImageRepositoryManagerBase
{
    private readonly IImageRepository _repository;

    public ImageService(IImageRepository repository)
    {
        _repository = repository;
    }

    public override Task<Void> Delete(DeleteImageRequest request, ServerCallContext context)
    {
        var id = new Guid(request.Name);
        
        _repository.RemoveAsync(id);
        
        return Task.FromResult(new Void());
    }

    public override async Task<UploadImageResponse> Upload(IAsyncStreamReader<UploadImageRequest> requestStream, ServerCallContext context)
    {
        var image = new Image();
        
        await foreach (var message in requestStream.ReadAllAsync())
        {
            var filename = message.Metadata.Name;

            image.Id = Guid.NewGuid();
            image.Metadata = new()
            {
                Name = filename.Split('.')[0],
                Extension = filename.Split('.')[1]
            };
            image.Data = message.Data.ToArray();

            await _repository.CreateAsync(image);
        }

        return new UploadImageResponse() { Id = image.Id.ToString() };
    }
}