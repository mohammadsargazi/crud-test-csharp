using MongoDB.Entities;

namespace Domain.Entities.Base;

public class BaseEntity : Entity
{
    public DateTime CreateDate { get; protected set; }
}
