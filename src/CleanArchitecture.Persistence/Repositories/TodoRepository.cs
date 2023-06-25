using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories;

public class TodoRepository : BaseRepository<Guid, Todo>, ITodoRepository
{

    public TodoRepository(TodoDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<Todo>> GetDoneTodos(CancellationToken cancellationToken)
    {
        return await DbContext.Todos.Where(todo => todo.Status == TodoStatus.Done).AsNoTracking().ToListAsync(cancellationToken);
    }
}
