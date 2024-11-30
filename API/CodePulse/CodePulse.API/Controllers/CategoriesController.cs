using CodePulse.Application.Dtos.Categories.Create;
using CodePulse.Application.Dtos.Categories.Results;
using CodePulse.Application.Interfaces.Services;
using CodePulse.Application.Routes;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers;

[ApiController]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [Produces<List<CategoryResultDto>>]
    [HttpGet(ApiRoutes.Categories.List)]
    public async Task<IActionResult> List()
    {
        var result = await categoryService.GetListAsync();
        return Ok(result);
    }
    
    [Produces<CategoryResultDto>]
    [HttpGet(ApiRoutes.Categories.Single)]
    public async Task<IActionResult> Single(Guid id)
    {
        var result = await categoryService.GetAsync(id);
        return Ok(result);
    }

    [HttpPost(ApiRoutes.Categories.Create)]
    public async Task<IActionResult> Create(CategoryCommand command)
    {
        await categoryService.CreateAsync(command);
        return Ok();
    }
    
    [HttpPut(ApiRoutes.Categories.Update)]
    public async Task<IActionResult> Update(Guid id, CategoryCommand command)
    {
        await categoryService.UpdateAsync(id, command);
        return Ok();
    }
    
    
    [HttpDelete(ApiRoutes.Categories.Delete)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await categoryService.DeleteAsync(id);
        return Ok();
    }
}