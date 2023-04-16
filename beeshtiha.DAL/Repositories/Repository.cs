using beeshtiha.DAL.DbContexts;
using beeshtiha.DAL.IRepositories;
using Beeshtiha.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace beeshtiha.DAL.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    protected readonly BeeshtihaDbContext dbContext;
    protected readonly DbSet<TEntity> dbSet;

    public Repository(BeeshtihaDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<TEntity>();
    }
    public async ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await this.SelectAsync(expression);

        if (entity is not null)
        {
            this.dbSet.Remove(entity);
            return true;
        }

        return false;
    }

    public bool DeleteMany(Expression<Func<TEntity, bool>> expression)
    {
        var entities = dbSet.Where(expression);
        if (entities.Any())
        {
            this.dbSet.RemoveRange(entities);

            return true;
        }

        return false;
    }

    public async ValueTask<TEntity> InsertAsync(TEntity entity)
    {
        EntityEntry<TEntity> entry = await this.dbSet.AddAsync(entity);

        return entry.Entity;
    }

    public async ValueTask SaveAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, string[] includes = null)
    {
        IQueryable<TEntity> query = expression is null ? this.dbSet : this.dbSet.Where(expression);

        if (includes is not null)
        {
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
        }
        return query;
    }

    public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        => await this.SelectAll(expression, includes).FirstOrDefaultAsync();

    public TEntity Update(TEntity entity)
    {
        EntityEntry<TEntity> entryentity = this.dbContext.Update(entity);

        return entryentity.Entity;
    }
}
