using System;
using Microsoft.AspNetCore.Mvc;
using eShop.Services.Catalog.API.Models;
using eShop.Services.Catalog.API.Repositories;

namespace eShop.Services.Catalog.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CatalogController : Controller
{
    private readonly ICatalogRepository _repository;

    public CatalogController(ICatalogRepository repository)
    {
        _repository = repository;
    }

    [HttpDelete("id")]
    public IActionResult Delete(Guid id)
    {
        var item = _repository.GetCatalogItem(id);

        if (item is null)
        {
            return NotFound();
        }

        _repository.DeleteCatalogItem(item);
        _repository.Save();

        return Ok(item);
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int pageSize = 24, [FromQuery] int pageIndex = 0)
    {
        return Ok(_repository.GetCatalog(pageSize, pageIndex));
    }

    [HttpGet("id")]
    public IActionResult Get(Guid id)
    {
        var item = _repository.GetCatalogItem(id);

        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CatalogItem item)
    {
        if (item.Id != Guid.Empty
            && _repository.GetCatalogItem(item.Id) is not null)
        {
            return BadRequest();
        }

        _repository.CreateCatalogItem(item);
        _repository.Save();

        return Ok(item);
    }

    [HttpPut("id")]
    public IActionResult Put(Guid id, CatalogItem editItem)
    {
        var item = _repository.GetCatalogItem(id);

        if (item is null)
        {
            return NotFound();
        }

        item.Name = editItem.Name;
        item.Description = editItem.Description;
        item.Price = editItem.Price;

        _repository.Save();

        return Ok();
    }

}