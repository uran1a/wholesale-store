using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WholesaleStore.Common.Security;
using WholesaleStore.Services.Products.Products;
using WholesaleStore.Services.Products.Products.Models;

namespace WholesaleStore.Api.Controllers;

[ApiController]
[Authorize]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("v{version:apiVersion}/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService productService;

    public ProductController(IProductService productService)
    {
        this.productService = productService;
    }

    [HttpGet("")]
    [Authorize(AppScopes.ProductsRead)]
    public async Task<IEnumerable<ProductModel>> GetAll()
    {
        var result = await productService.GetAll();

        return result;
    }

    [HttpPut("{id:Guid}")]
    [Authorize(AppScopes.ProductsWrite)]
    public async Task Update([FromRoute] Guid id, UpdateModel request)
    {
        await productService.Update(id, request);
    }
}
