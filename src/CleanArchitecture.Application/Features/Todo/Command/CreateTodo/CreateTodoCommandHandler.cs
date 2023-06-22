using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using MediatR;
using Shared.Application.Contracts.Persistence;
using Shared.Application.Responses;

namespace CleanArchitecture.Application.Features.Todo.Command.CreateTodo;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, BaseResponse<CreateTodoVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Guid, Domain.Entities.Todo> _todoRepository;
    private readonly IEmailService _emailService;

    public CreateTodoCommandHandler(
        IMapper mapper,
        IAsyncRepository<Guid, Domain.Entities.Todo> todoRepository,
        IEmailService emailService
    )
    {
        _mapper = mapper;
        _todoRepository = todoRepository;
        _emailService = emailService;
    }
    
    public async Task<BaseResponse<CreateTodoVm>> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var createTodoCommandResponse = new BaseResponse<CreateTodoVm>();
        
        var validator = new CreateTodoCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Count > 0)
        {
            return
                createTodoCommandResponse with
                    { Success = false,
                      ValidationErrors = validationResult.Errors.Select(er => er.ErrorMessage).ToList() };
        }

        var todo = new Domain.Entities.Todo() { Name = request.Name };
        todo = await _todoRepository.AddAsync(todo, cancellationToken);

        // var email = new Email()
        // {
        //     To = "bochorishvili.temur@gmail.com",
        //     Body = "Test",
        //     Subject = "Test"
        // };
        //
        // try
        // {
        //     await _emailService.SendMail(email);
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine(e);
        //     throw;
        // }
        
        return createTodoCommandResponse with { Response = _mapper.Map<CreateTodoVm>(todo) };
    }
}