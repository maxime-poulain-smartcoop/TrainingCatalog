using Microsoft.EntityFrameworkCore;
using Smart.FA.Catalog.Web.Domain.Entities.Base;

namespace Smart.FA.Catalog.Web.Infrastructure.Data.Extensions;

public static class DbSetExtensions
{
    public static async Task<bool> ExistsAsync<TEntity, TKey>(this DbSet<TEntity> set, TKey id, CancellationToken cancellationToken = default) where TEntity : Entity, IEntity<TKey>
    {
        return await set.FindAsync(new object?[] { id }, cancellationToken: cancellationToken).ConfigureAwait(false) is not null;
    }

    public static async Task<bool> ExistsAllAsync<TEntity, TKey>(this DbSet<TEntity> set, ICollection<TKey>? ids, CancellationToken cancellationToken = default)
        where TEntity : Entity, IEntity<TKey>
    {
        if (ids is null)
            return true;

        return await set.CountAsync(item => ids.Contains(item.Id!), cancellationToken).ConfigureAwait(false) == ids.Count;
    }
}
