using MediatR;

namespace Shared.Application.Mediator;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
