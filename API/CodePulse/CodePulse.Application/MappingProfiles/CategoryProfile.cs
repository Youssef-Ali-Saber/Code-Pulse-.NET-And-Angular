using AutoMapper;
using CodePulse.Application.Dtos.Categories.Create;
using CodePulse.Application.Dtos.Categories.Results;
using CodePulse.Domain.Entities;

namespace CodePulse.Application.MappingProfiles;

public class CategoryProfile : BaseProfile
{
    public CategoryProfile()
    {
        CreateMap<CategoryCommand, Category>();
        CreateMap<Category, CategoryResultDto>();
    }
}