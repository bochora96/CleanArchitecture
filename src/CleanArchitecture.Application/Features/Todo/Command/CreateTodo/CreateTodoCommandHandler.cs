using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using Shared.Application.Contracts.Persistence;
using Shared.Application.Mediator;
using Shared.Application.Responses;

namespace CleanArchitecture.Application.Features.Todo.Command.CreateTodo;

public class CreateTodoCommandHandler : ICommandHandler<CreateTodoCommand, BaseResponse<CreateTodoVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Guid, Domain.Entities.Todo> _todoRepository;

    public CreateTodoCommandHandler(
        IMapper mapper,
        IAsyncRepository<Guid, Domain.Entities.Todo> todoRepository,
        IEmailService emailService
    )
    {
        _mapper = mapper;
        _todoRepository = todoRepository;
    }
    
    public async Task<BaseResponse<CreateTodoVm>> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var createTodoCommandResponse = new BaseResponse<CreateTodoVm>();
        
        var todo = new Domain.Entities.Todo() { Name = request.Name };
        todo = await _todoRepository.AddAsync(todo, cancellationToken);
        
        return createTodoCommandResponse with { Response = _mapper.Map<CreateTodoVm>(todo) };
    }
}