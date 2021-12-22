namespace Smart.FA.Catalog.Web.Infrastructure.Data;

public interface IEntity<TKey>
{
    TKey? Id { get; set; }
}
