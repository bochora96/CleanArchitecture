using MediatR;
using Shared.Application.Mediator;

namespace CleanArchitecture.Persistence.PipelineBehaviours;

public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly TodoDbContext _context;

    public TransactionBehaviour(TodoDbContext context)
    {
        _context = context;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_context.HasActiveTransaction || !(request is ICommand<TResponse>))
        {
            return await next();
        }

        try
        {
            var transaction = await _context.BeginTransactionAsync(cancellationToken);

            var response = await next();
        
            await _context.CommitTransactionAsync(transaction, cancellationToken);
        
            return response;
        }
        catch (Exception _)
        {
            await _context.RollbackTransaction(cancellationToken);
            // ex.Data.Add("PreviousStackTrace", ex.StackTrace);
            
            throw;
        }
    }
}
