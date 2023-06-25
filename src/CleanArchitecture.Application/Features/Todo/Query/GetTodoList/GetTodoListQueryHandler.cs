using AutoMapper;
using MediatR;
using Shared.Application.Contracts.Persistence;

namespace CleanArchitecture.Application.Features.Todo.Query.GetTodoList;

public class GetTodoListQueryHandler : IRequestHandler<GetTodoListQuery, List<TodoListVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Guid, Domain.Entities.Todo> _todoRepository;

    public GetTodoListQueryHandler(
        IMapper mapper,
        IAsyncRepository<Guid, Domain.Entities.Todo> todoRepository
    )
    {
        _mapper = mapper;
        _todoRepository = todoRepository;
    }
    
    public async Task<List<TodoListVm>> Handle(GetTodoListQuery request, CancellationToken cancellationToken)
    {
        var allTodos = (await _todoRepository.ListAllAsync(cancellationToken)).OrderBy(td => td.DateCreated).ToList();

        return _mapper.Map<List<TodoListVm>>(allTodos);
    }
}
