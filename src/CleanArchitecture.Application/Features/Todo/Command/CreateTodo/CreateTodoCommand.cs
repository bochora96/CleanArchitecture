using MediatR;
using Shared.Application.Responses;

namespace CleanArchitecture.Application.Features.Todo.Command.CreateTodo;

public record CreateTodoCommand(string Name) : IRequest<BaseResponse<CreateTodoVm>>;