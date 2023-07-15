using Microsoft.AspNetCore.Mvc;
using Xunit;
using eShop.Services.Catalog.API.Controllers;
using eShop.Services.Catalog.API.Models;
using eShop.Services.Catalog.API.Repositories;

namespace UnitTest.Catalog.Application;

public class CatalogControllerTest
{
    [Fact]
    public void Delete_ContainingCatalogItem_ReturnsOk()
    {
        // Arrange
        var id = Guid.NewGuid();
        var item = GetTestCatalogItem(id);

        var fakeRepository = new FakeRepository() { ContainingCatalogItem = item };
        var controller = new CatalogController(fakeRepository);

        // Act
        var actionResult = controller.Delete(id);

        // Assert
        var result = Assert.IsType<OkObjectResult>(actionResult);
        var actual = Assert.IsType<CatalogItem>(result.Value);
        Assert.Equal(id, actual.Id);
    }

    [Fact]
    public void Delete_ContainingCatalogItem_RemoveItem()
    {
        // Arrange
        var id = Guid.NewGuid();
        var item = GetTestCatalogItem(id);

        var stubRepository = new FakeRepository() { ContainingCatalogItem = item };
        var controller = new CatalogController(stubRepository);

        // Act
        controller.Delete(id);

        // Assert
        Assert.True(stubRepository.IsChanged);
        Assert.True(stubRepository.IsSaved);
    }

    [Fact]
    public void Delete_NotContainingCatalogItem_ReturnsNotFound()
    {
        // Arrange
        var id = Guid.NewGuid();

        var fakeRepository = new FakeRepository() { ContainingCatalogItem = null };
        var controller = new CatalogController(fakeRepository);

        // Act
        var actionResult = controller.Delete(id);

        // Assert
        Assert.IsType<NotFoundResult>(actionResult);
    }

    [Fact]
    public void Post_ValidCatalogItem_ReturnsOk()
    {
        // Arrange
        var item = GetTestCatalogItem(Guid.Empty);
        
        var fakeRepository = new FakeRepository() { ContainingCatalogItem = null };
        var controller = new CatalogController(fakeRepository);

        // Act
        var actionResult = controller.Post(item);

        // Assert
        var result = Assert.IsType<OkObjectResult>(actionResult);
        var actual = Assert.IsType<CatalogItem>(result.Value);
        Assert.Equal(item.Name, actual.Name);
        Assert.Equal(item.Description, actual.Description);
        Assert.Equal(item.Price, actual.Price);
    }

    [Fact]
    public void Post_ValidCatalogItem_IsCreated()
    {
        // Arrange
        var item = GetTestCatalogItem(Guid.Empty);

        var stubRepository = new FakeRepository() { ContainingCatalogItem = null};
        var controller = new CatalogController(stubRepository);

        // Act
        controller.Post(item);

        // Assert
        Assert.True(stubRepository.IsSaved);
    }

    [Fact]
    public void Post_InvalidCatalogItem_ReturnsBadRequest()
    {
        // Arrange
        var id = Guid.NewGuid();
        var item = GetTestCatalogItem(id);

        var fakeRepository = new FakeRepository() { ContainingCatalogItem = item};
        var controller = new CatalogController(fakeRepository);

        // Act
        var actionResult = controller.Post(item);
        
        // Assert
        Assert.IsType<BadRequestResult>(actionResult);
    }
    
    private CatalogItem GetTestCatalogItem(Guid id)
    {
        return new CatalogItem()
        {
            Id = id,
            Name = "Test",
            Description = "This is item for test",
            ImageUrls = new[] { "image1.jpg", "image2.jpg" },
            Price = 100
        };
    }
}

public class FakeRepository : ICatalogRepository
{
    public CatalogItem? ContainingCatalogItem { get; set; } = null;
    public bool IsChanged { get; private set; } = false;
    public bool IsSaved { get; private set; } = false;

    public void CreateCatalogItem(CatalogItem item)
    {
        IsChanged = true;
    }

    public void DeleteCatalogItem(CatalogItem item)
    {
        IsChanged = true;
    }

    public IEnumerable<CatalogItem> GetCatalog()
    {
        return new[] { ContainingCatalogItem }!;
    }

    public IEnumerable<CatalogItem> GetCatalog(int size, int index)
    {
        return new[] { ContainingCatalogItem }!;
    }

    public CatalogItem? GetCatalogItem(Guid id)
    {
        return ContainingCatalogItem;
    }

    public void Save()
    {
        IsSaved = true;
    }
}