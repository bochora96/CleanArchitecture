using Shared.Application.Mediator;

namespace CleanArchitecture.Application.Features.Todo.Query.GetTodoDetails;

public record GetTodoDetailsQuery(Guid Id) : IQuery<TodoDetailsVm>;
