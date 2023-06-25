using MediatR;
using Shared.Application.Contracts.Persistence;
using Shared.Application.Mediator;

namespace CleanArchitecture.Application.Features.Todo.Command.DeleteTodo;

public class DeleteTodoCommandHandler : ICommandHandler<DeleteTodoCommand, Unit>
{
    private readonly IAsyncRepository<Guid, Domain.Entities.Todo> _todoRepository;

    public DeleteTodoCommandHandler(IAsyncRepository<Guid, Domain.Entities.Todo> todoRepository)
    {
        _todoRepository = todoRepository;
    }
    
    public async Task<Unit> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todoToDelete = await _todoRepository.GetByIdAsync(request.Id, cancellationToken);

        // TODO check if is null
        // How can i use custom exceptions
        if (todoToDelete is null)
        {
            // return something
        }

        await _todoRepository.DeleteAsync(todoToDelete!, cancellationToken);

        return Unit.Value;
    }
}
