using Microsoft.EntityFrameworkCore;
using eShop.Services.Catalog.API.Models;

namespace eShop.Services.Catalog.API.Data;

public class CatalogContext : DbContext
{
    public CatalogContext(DbContextOptions<CatalogContext> context) : base(context) { }

    public DbSet<CatalogItem> CatalogItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // todo: вынести connection string
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=catalog;username=postgres;Password=5807");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}