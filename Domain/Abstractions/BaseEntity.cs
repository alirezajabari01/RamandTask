using System.ComponentModel.DataAnnotations;

namespace Domain.Abstractions;

public abstract class BaseEntity<TKey> : IEntity
{
    [Key] public TKey Id { get; set; }

    public DateTime? DeletedDate { get; set; } = null;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}