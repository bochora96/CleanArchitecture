using MediatR;

namespace CleanArchitecture.Application.Features.Todo.Query.GetTodoList;

public record GetTodoListQuery : IRequest<List<TodoListVm>>;
