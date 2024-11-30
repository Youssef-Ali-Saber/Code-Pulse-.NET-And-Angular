using CodePulse.Domain.Entities;
using CodePulse.Domain.Interfaces.Repositories;
using CodePulse.Infrastructure.Data.Context;
using CodePulse.Infrastructure.Implementations.Repositories.GenericRepository;

namespace CodePulse.Infrastructure.Implementations.Repositories;

public class CategoryRepository(ApplicationDbContext applicationDbContext)
    : GenericRepository<Category>(applicationDbContext), ICategoryRepository;