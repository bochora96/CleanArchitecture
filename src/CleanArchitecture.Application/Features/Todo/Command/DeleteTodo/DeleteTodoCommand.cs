using MediatR;
using Shared.Application.Mediator;

namespace CleanArchitecture.Application.Features.Todo.Command.DeleteTodo;

public record DeleteTodoCommand(Guid Id) : ICommand<Unit>;
