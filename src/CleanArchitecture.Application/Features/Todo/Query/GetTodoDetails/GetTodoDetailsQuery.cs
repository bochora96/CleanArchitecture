using MediatR;

namespace CleanArchitecture.Application.Features.Todo.Query.GetTodoDetails;

public class GetTodoDetailsQuery : IRequest<TodoDetailsVm>
{
    public Guid Id { get; set; }
}
