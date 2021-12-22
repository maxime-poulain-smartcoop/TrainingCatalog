using Smart.FA.Catalog.Web.Infrastructure.Data;

namespace Smart.FA.Catalog.Web.Domain.Entities.Base;

public class Entity
{

}

public class Entity<TKey> : Entity, IEntity<TKey>
{
    public TKey? Id { get; set; }
}
