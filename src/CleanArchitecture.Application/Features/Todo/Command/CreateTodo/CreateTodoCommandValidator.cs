using FluentValidation;

namespace CleanArchitecture.Application.Features.Todo.Command.CreateTodo;

public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoCommandValidator()
    {
        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(4).WithMessage("{PropertyName} must not exceed 50");
    }
}