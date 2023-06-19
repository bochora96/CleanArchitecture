using Microsoft.EntityFrameworkCore;
using Shared.Application.Contracts.Persistence;
using Shared.Domain;

namespace Shared.Persistence.Repositories;

public class BaseRepository<TKey, T, TDbContext> : IAsyncRepository<TKey, T>
    where TKey : struct, IEquatable<TKey>
    where T : AuditableEntity<Guid>
    where TDbContext : DbContext
{
    private readonly TDbContext _dbContext;

    public BaseRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<T?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<T>().FirstOrDefaultAsync(entity => entity.Id.Equals(id), cancellationToken);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
        // TODO review if we need this here
        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        // TODO review if we need this here
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        // Todo find out is this same es remove?
        // _dbContext.Entry(entity).State = EntityState.Deleted;
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}