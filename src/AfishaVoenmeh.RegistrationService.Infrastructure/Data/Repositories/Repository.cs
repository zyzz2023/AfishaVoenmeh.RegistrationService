using AfishaVoenmeh.RegistrationService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.RegistrationService.Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AfishaVoenmeh.RegistrationService.Infrastructure.Data.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity<Guid>
{
    protected ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
       await _context.AddAsync(entity, cancellationToken);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _context
             .Set<TEntity>()
             .CountAsync(predicate, cancellationToken);
    }

    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Set<TEntity>().Remove(entity);

        return Task.CompletedTask;
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _context
            .Set<TEntity>()
            .AnyAsync(predicate, cancellationToken);
    }

    public async Task<IEnumerable<TEntity?>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context
            .Set<TEntity>()
            .ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, bool enableTracking, CancellationToken cancellationToken = default)
    {
        var query = _context.Set<TEntity>()
           .AsQueryable();

        if (!enableTracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Update(entity);

        return Task.CompletedTask;
    }
}
