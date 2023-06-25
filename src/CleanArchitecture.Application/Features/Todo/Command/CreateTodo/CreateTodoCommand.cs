using Shared.Application.Mediator;
using Shared.Application.Responses;

namespace CleanArchitecture.Application.Features.Todo.Command.CreateTodo;

public record CreateTodoCommand(string Name) : ICommand<BaseResponse<CreateTodoVm>>;
