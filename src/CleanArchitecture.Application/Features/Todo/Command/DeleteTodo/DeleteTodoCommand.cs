using MediatR;

namespace CleanArchitecture.Application.Features.Todo.Command.DeleteTodo;

public record DeleteTodoCommand(Guid Id) : IRequest<Unit>;