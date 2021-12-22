
namespace Smart.FA.Catalog.Web.Infrastructure.Data.Extensions;

public static class IQueryableExtensions
{
    /// <summary>
    /// Applies pagination to a SQL statement.
    /// </summary>
    /// <param name="query">Source query to which the pagination will be applied.</param>
    /// <param name="page">Page from which the result is returned.</param>
    /// <param name="size">Number of item per page.</param>
    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page, int size) where T: class
    {
        return query.Skip(Math.Max(page - 1, 0) * size).Take(size);
    }
}
