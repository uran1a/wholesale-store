using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WholesaleStore.Services.Products.Products;
using WholesaleStore.Services.Products.Products.Models;

namespace WholesaleStore.Api.Controllers;

[ApiController]
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
    public async Task<IEnumerable<ProductModel>> GetAll()
    {
        var result = await productService.GetAll();

        return result;
    }
}
