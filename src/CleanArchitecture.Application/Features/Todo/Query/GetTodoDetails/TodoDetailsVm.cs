using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Todo.Query.GetTodoDetails;

public record TodoDetailsVm(
    Guid Id,
    string Name,
    TodoStatus TodoStatus
);
