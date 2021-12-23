using Microsoft.AspNetCore.Mvc.Filters;

namespace Smart.FA.Catalog.Web.Infrastructure.PageFilters;

public class NotFoundPageFilter : IAsyncPageFilter
{
    public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
    {

        var c = context.HttpContext.Response.StatusCode;

        return Task.CompletedTask;
        ;
    }

    public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
    {
        var c = context.HttpContext.Response.StatusCode;
        await next();
        var d = context.HttpContext.Response.StatusCode;
    }
}
