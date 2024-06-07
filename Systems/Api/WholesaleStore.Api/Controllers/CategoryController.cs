using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WholesaleStore.Services.Categories.Categories;
using WholesaleStore.Services.Categories.Categories.Models;

namespace WholesaleStore.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Category")]
[Route("api/v{version:apiVersion}/categories")]
public class CategoryController(
        ICategoryService categoryService
    ) : ControllerBase
{
    private readonly ICategoryService categoryService = categoryService;

    [HttpGet("")]
    public async Task<IEnumerable<CategoryModel>> GetAll()
    {
        var result = await categoryService.GetAll();

        return result;
    }

    [HttpPost("create")]
    public async Task<CategoryModel> Create([FromBody] CreateCategoryModel request)
    {
        return await categoryService.Create(request);
    }
}
