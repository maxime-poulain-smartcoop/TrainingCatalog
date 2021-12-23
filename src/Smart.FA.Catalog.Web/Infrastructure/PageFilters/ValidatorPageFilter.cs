using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Smart.FA.Catalog.Web.Infrastructure.PageFilters;

public class ValidatorPageFilter : IPageFilter
{
    public void OnPageHandlerSelected(PageHandlerSelectedContext context)
    {
    }

    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            if (context.HttpContext.Request.Method == "GET")
            {
                var result = new BadRequestResult();
                context.Result = result;
            }
            else
            {
                var result = new ContentResult();
                var content = JsonSerializer.Serialize(context.ModelState);
                result.Content     = content;
                result.ContentType = "application/json";

                context.HttpContext.Response.StatusCode = 400;
                context.Result                          = result;
            }
        }
    }

    public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {
    }
}
