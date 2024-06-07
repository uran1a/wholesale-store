using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WholesaleStore.Common.Security;
using WholesaleStore.Context.Entities;
using WholesaleStore.Services.Products.Products;
using WholesaleStore.Services.Products.Products.Models;

namespace WholesaleStore.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("api/v{version:apiVersion}/products")]
public class ProductController(
        IProductService productService
    ) : ControllerBase
{
    private readonly IProductService productService = productService;

    [HttpGet("")]
    public async Task<IEnumerable<ProductModel>> GetAll()
    {
        var result = await productService.GetAll();

        return result;
    }

    [HttpGet("{id:Guid}")]
    public async Task<ProductModel> GetById([FromRoute] Guid id)
    {
        var result = await productService.GetById(id);

        return result;
    }

    [HttpPost("create")]
    public async Task<ProductModel> Create([FromBody] CreateProductModel request)
    {
        return await productService.Create(request);
    }

    [HttpPut("{id:Guid}")]
    public async Task Update([FromRoute] Guid id, UpdateModel request)
    {
        await productService.Update(id, request);
    }

    [HttpGet("search")]
    public async Task<IEnumerable<ProductModel>> Search(
        [FromQuery(Name = "title")] string title = "",
        [FromQuery(Name = "price_min")] double priceMin = 0.0,
        [FromQuery(Name = "price_max")] double priceMax = 0.0,
        [FromQuery(Name = "categoryId")] string categoryUId = "")
    {
        var result = await productService.Search(title, priceMin, priceMax, categoryUId);

        return result;
    }
}