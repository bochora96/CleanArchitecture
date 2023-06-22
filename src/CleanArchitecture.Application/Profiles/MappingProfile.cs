using AutoMapper;
using CleanArchitecture.Application.Features.Todo.Command.CreateTodo;
using CleanArchitecture.Application.Features.Todo.Query.GetTodoDetails;
using CleanArchitecture.Application.Features.Todo.Query.GetTodoList;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Todo, TodoListVm>().ReverseMap();
        CreateMap<Todo, TodoDetailsVm>().ReverseMap();

        CreateMap<Todo, CreateTodoVm>().ReverseMap();
    }
}
