using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TimeZone.Core.Entities.Commons;
using TimeZone.DAL.Contexts;
using TimeZone.DAL.Repositories.Interfaces;

namespace TimeZone.DAL.Repositories.Implements;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
{
    public AppDbContext _context;
public Repository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<TEntity> Table => _context.Set<TEntity>();

    public  async Task CreateAsync(TEntity entity)
    {
      await Table.AddAsync(entity);
    }

    public void Delete(TEntity entity)
    {
        Table.Remove(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await FindByIdAsync(id);
        Table.Remove(entity);
    }

    public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression, params string[] includes)
    {
        return _getIncludes(Table, includes).Where(expression);
    }

    public Task<TEntity> FindByIdAsync(int id, params string[] includes)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> GetAll(params string[] includes)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetSingleAsnyc(Expression<Func<TEntity, bool>> expression, params string[] includes)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public void RevertSoftDelete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void SoftDelete(TEntity entity)
    {
        throw new NotImplementedException();
    }
    IQueryable<TEntity> _getIncludes(IQueryable<TEntity> query, params string[] includes)
    {
        foreach (var item in includes)
        {
            query = query.Include(item);
        }
        return query;
    }
}
