using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholesaleStore.Context.Context;
using WholesaleStore.Services.Categories.Categories.Models;

namespace WholesaleStore.Services.Categories.Categories;

public class CategoryService(
        IDbContextFactory<MainDbContext> dbContextFactory,
        IMapper mapper
    ) : ICategoryService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory = dbContextFactory;
    private readonly IMapper mapper = mapper;

    public async Task<IEnumerable<CategoryModel>> GetAll()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var categories = await context.Categories.ToListAsync();

        var result = mapper.Map<IEnumerable<CategoryModel>>(categories);

        return result;
    }
}
