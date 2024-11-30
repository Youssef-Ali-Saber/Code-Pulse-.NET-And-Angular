using System.Linq.Expressions;
using CodePulse.Domain.Entities.Base;

namespace CodePulse.Domain.Interfaces.Repositories.GenericRepository;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    IQueryable<TEntity> GetAll();
    Task<TEntity?> GetByIdAsync<TKey>(TKey id);
    IQueryable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter);
    IQueryable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes);
    IQueryable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes, List<Expression<Func<TEntity, object>>> orderBy);
    Task CreateAsync(TEntity entity);
    Task DeleteAsync<TKey>(TKey id);
    void Update(TEntity entity);
    Task SaveChangesAsync();
}