using Shared.Domain;

namespace CleanArchitecture.Domain.Entities;

public class Todo : AuditableEntity<Guid>
{
    public string Name { get; set; } = null!;

    public TodoStatus Status { get; set; }
}
