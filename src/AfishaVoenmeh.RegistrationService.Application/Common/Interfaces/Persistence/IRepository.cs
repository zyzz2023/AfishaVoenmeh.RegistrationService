using AfishaVoenmeh.RegistrationService.Domain.Common.Interfaces;
using System.Linq.Expressions;

namespace AfishaVoenmeh.RegistrationService.Application.Common.Interfaces.Persistence;

public interface IRepository<TEntity>
    where TEntity : class, IEntity<Guid>
{
    Task<TEntity?> GetByIdAsync(Guid id, bool enableTraking, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity?>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}
