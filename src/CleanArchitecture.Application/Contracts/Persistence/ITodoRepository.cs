using CleanArchitecture.Domain.Entities;
using Shared.Application.Contracts.Persistence;

namespace CleanArchitecture.Application.Contracts.Persistence;

public interface ITodoRepository : IAsyncRepository<Guid, Todo>
{
    Task<IReadOnlyList<Todo>> GetDoneTodos(CancellationToken cancellationToken);
}
