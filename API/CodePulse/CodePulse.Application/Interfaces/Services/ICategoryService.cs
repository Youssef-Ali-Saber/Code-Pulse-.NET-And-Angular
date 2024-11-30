using CodePulse.Application.Dtos.Categories.Create;
using CodePulse.Application.Dtos.Categories.Results;

namespace CodePulse.Application.Interfaces.Services;

public interface ICategoryService : IBaseService
{
    Task<List<CategoryResultDto>> GetListAsync();
    Task<CategoryResultDto> GetAsync(Guid id);
    Task CreateAsync(CategoryCommand command);
    
    Task UpdateAsync(Guid id, CategoryCommand command);
    
    Task DeleteAsync(Guid id);
}