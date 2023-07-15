using eShop.Services.Catalog.API.Models;

namespace eShop.Services.Catalog.API.Repositories;

public interface ICatalogRepository
{
    void CreateCatalogItem(CatalogItem item);
    void DeleteCatalogItem(CatalogItem item);
    IEnumerable<CatalogItem> GetCatalog();
    IEnumerable<CatalogItem> GetCatalog(int size, int index);
    CatalogItem? GetCatalogItem(Guid id);
    void Save();
}