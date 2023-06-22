using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Features.Todo.Command.CreateTodo;
using CleanArchitecture.Application.Features.Todo.Query.GetTodoList;
using Shared.Application.Responses;

namespace CleanArchitecture.Api.Controllers;

[ApiController]
[Route("/api/Todos")]
public class TodoController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<TodoListVm>>> GetAll()
    {
        var todos = await _mediator.Send(new GetTodoListQuery());

        return Ok(todos);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<BaseResponse<CreateTodoVm>>> Add([FromBody] CreateTodoCommand createTodoCommand)
    {
        var response = await _mediator.Send(createTodoCommand);

        return response;
    }
}
