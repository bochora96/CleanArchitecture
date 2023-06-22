using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Todo.Query.GetTodoList;

// TODO Error when this type is record
public class TodoListVm
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; }
    
    public TodoStatus TodoStatus { get; set; }
}
