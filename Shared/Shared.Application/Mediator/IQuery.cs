using MediatR;

namespace Shared.Application.Mediator;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
