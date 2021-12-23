using FluentValidation.AspNetCore;
using Smart.Design.Razor.Extensions;
using Smart.FA.Catalog.Web.Extensions;
using Smart.FA.Catalog.Web.Infrastructure.PageFilters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(cfg =>
    {
        cfg.Conventions.ConfigureFilter(new NotFoundPageFilter());
        cfg.RootDirectory = "/Features";
    })
    .AddFluentValidation(cfg =>
    {
        cfg.RegisterValidatorsFromAssemblyContaining<Program>();
        cfg.DisableDataAnnotationsValidation = true;
    })
    ;

builder.Services.AddSmartDesign();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/404";
        await next();
    }
});

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
