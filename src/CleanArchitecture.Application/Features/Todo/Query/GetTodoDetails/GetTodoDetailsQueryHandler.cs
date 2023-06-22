using AutoMapper;
using MediatR;
using Shared.Application.Contracts.Persistence;

namespace CleanArchitecture.Application.Features.Todo.Query.GetTodoDetails;

public class GetTodoDetailsQueryHandler : IRequestHandler<GetTodoDetailsQuery, TodoDetailsVm>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Guid, Domain.Entities.Todo> _todoRepository;

    public GetTodoDetailsQueryHandler(
        IMapper mapper,
        IAsyncRepository<Guid, Domain.Entities.Todo> todoRepository
    )
    {
        _mapper = mapper;
        _todoRepository = todoRepository;
    }

    public async Task<TodoDetailsVm> Handle(
        GetTodoDetailsQuery request,
        CancellationToken cancellationToken
    )
    {
        var todo = await _todoRepository.GetByIdAsync(request.Id, cancellationToken);
        var todoDetailsVm = _mapper.Map<TodoDetailsVm>(todo);

        return todoDetailsVm;
    }
}
