namespace Shared.Domain;

public class AuditableEntity<T> where T : struct, IEquatable<T>, IFormattable
{
    public T Id { get; set; }
    
    public string? CreatedBy { get; set; }

    public DateTime DateCreated { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }
}