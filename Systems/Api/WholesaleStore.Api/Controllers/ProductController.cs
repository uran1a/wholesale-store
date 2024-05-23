using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WholesaleStore.Common.Security;
using WholesaleStore.Context.Entities;
using WholesaleStore.Services.Products.Products;
using WholesaleStore.Services.Products.Products.Models;

namespace WholesaleStore.Api.Controllers;

[ApiController]
//[Authorize]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("api/v{version:apiVersion}/products")]
public class ProductController(
        IProductService productService
    ) : ControllerBase
{
    private readonly IProductService productService = productService;

    [HttpGet("")]
    //[Authorize(AppScopes.ProductsRead)]
    public async Task<IEnumerable<ProductModel>> GetAll()
    {
        var result = await productService.GetAll();

        return result;
    }

    [HttpPut("{id:Guid}")]
    //[Authorize(AppScopes.ProductsWrite)]
    public async Task Update([FromRoute] Guid id, UpdateModel request)
    {
        await productService.Update(id, request);
    }
}
