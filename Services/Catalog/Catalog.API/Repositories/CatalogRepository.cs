using eShop.Services.Catalog.API.Data;
using eShop.Services.Catalog.API.Models;

namespace eShop.Services.Catalog.API.Repositories;

public class CatalogRepository : ICatalogRepository
{
    private readonly CatalogContext _context;

    public CatalogRepository(CatalogContext context)
    {
        _context = context;
    }

    public void CreateCatalogItem(CatalogItem item)
    {
        _context.CatalogItems.Add(item);
    }

    public void DeleteCatalogItem(CatalogItem item)
    {
        _context.CatalogItems.Remove(item);
    }

    public IEnumerable<CatalogItem> GetCatalog()
    {
        return _context.CatalogItems.ToList();
    }

    public IEnumerable<CatalogItem> GetCatalog(int size, int index)
    {
        return _context.CatalogItems
            .OrderBy(item => item.Id)
            .Skip(size * index)
            .Take(size)
            .ToList();
    }

    public CatalogItem? GetCatalogItem(Guid id)
    {
        return _context.CatalogItems
            .Where(item => item.Id == id)
            .FirstOrDefault();
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}