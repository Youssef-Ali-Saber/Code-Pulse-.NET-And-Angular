using System.Linq.Expressions;
using CodePulse.Domain.Entities.Base;
using CodePulse.Domain.Interfaces.Repositories.GenericRepository;
using CodePulse.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.Infrastructure.Implementations.Repositories.GenericRepository;

public class GenericRepository<TEntity>(ApplicationDbContext dbContext) : IGenericRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly DbSet<TEntity> _table = dbContext.Set<TEntity>();

    public async Task CreateAsync(TEntity entity)
    {
        await _table.AddAsync(entity);
    }

    public async Task DeleteAsync<TKey>(TKey id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _table.Remove(entity);
        }
        else
        {
            throw new Exception("Entity not found");
        }
    }

    public IQueryable<TEntity> GetAll()
    {
        return _table;
    }

    public IQueryable<TEntity> GetByFilter(Expression<Func<TEntity,bool>> filter)
    {
        var entities = _table.Where(filter);
        return entities;
    }

    public IQueryable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes)
    {
        var entities = GetByFilter(filter);
        return includes.Aggregate(entities, (current, include) => current.Include(include));
    }

    public IQueryable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes, List<Expression<Func<TEntity, object>>> orderBy)
    {
        var entities = GetByFilter(filter, includes);
        return orderBy.Aggregate(entities, (current, order) => current.OrderBy(order));
    }

    public async Task<TEntity?> GetByIdAsync<TKey>(TKey id)
    {
        var entity = await _table.FindAsync(id);
        return entity;
    }

    public void Update(TEntity entity)
    {
        _table.Update(entity);
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }

}