using Microsoft.EntityFrameworkCore;
using Shared.Application.Contracts.Persistence;
using Shared.Domain;

namespace CleanArchitecture.Persistence.Repositories;

public class BaseRepository<TKey, T> : IAsyncRepository<TKey, T>
    where TKey : struct, IEquatable<TKey>, IFormattable
    where T : AuditableEntity<TKey>
{
    protected readonly TodoDbContext DbContext;

    public BaseRepository(TodoDbContext dbContext)
    {
        DbContext = dbContext;
    }
    
    public async Task<T?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
    {
        return await DbContext.Set<T>().FirstOrDefaultAsync(entity => entity.Id.Equals(id), cancellationToken);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken)
    {
        return await DbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await DbContext.Set<T>().AddAsync(entity, cancellationToken);
        // TODO review if we need this here
        await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        DbContext.Entry(entity).State = EntityState.Modified;
        // TODO review if we need this here
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        // Todo find out is this same es remove?
        // _dbContext.Entry(entity).State = EntityState.Deleted;
        DbContext.Set<T>().Remove(entity);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}