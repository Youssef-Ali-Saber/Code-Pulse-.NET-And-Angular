using CodePulse.Application.Dtos.Categories.Create;
using CodePulse.Application.Dtos.Categories.Results;
using CodePulse.Application.Interfaces.Services;
using CodePulse.Domain.Entities;
using CodePulse.Domain.Exceptions;
using CodePulse.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.Application.Implementations.Services;

public class CategoryService(ICategoryRepository categoriesRepo) : BaseService, ICategoryService
{
    public async Task<List<CategoryResultDto>> GetListAsync()
    {
        var categories = await categoriesRepo.GetAll().ToListAsync();
        
        var result =categories.Select(c => Mapper.Map<Category, CategoryResultDto>(c)).ToList();

        return result.Count == 0 ? null : result;
    }

    public async Task<CategoryResultDto> GetAsync(Guid id)
    {
        var category = await categoriesRepo.GetByIdAsync(id)
            ?? throw new EntityNotFoundException<Category>(id);
        
        var result = Mapper.Map<Category, CategoryResultDto>(category);
        
        return result;
    }

    public async Task CreateAsync(CategoryCommand command)
    {
        var category = Mapper.Map<CategoryCommand,Category>(command);
        
        await categoriesRepo.CreateAsync(category);
        
        await categoriesRepo.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, CategoryCommand command)
    {
        var category = await categoriesRepo.GetByIdAsync(id)
                       ?? throw new EntityNotFoundException<Category>(id);
        
        Mapper.Map(command, category);

        categoriesRepo.Update(category);
        
        await categoriesRepo.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var category = await categoriesRepo.GetByIdAsync(id)
                       ?? throw new EntityNotFoundException<Category>(id);
        
        await categoriesRepo.DeleteAsync(id);
        
        await categoriesRepo.SaveChangesAsync();
    }
}