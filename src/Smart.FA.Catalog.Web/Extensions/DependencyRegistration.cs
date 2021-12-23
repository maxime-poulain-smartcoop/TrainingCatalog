using MediatR;
using Microsoft.EntityFrameworkCore;
using Smart.FA.Catalog.Web.Domain.Options;
using Smart.FA.Catalog.Web.Infrastructure.Data.Context;

namespace Smart.FA.Catalog.Web.Extensions;

public static class DependencyRegistration
{
    public static IServiceCollection AddCatalogDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddConfiguration(configuration)
            .AddDbContext<CatalogContext>(builder => builder.UseSqlServer(configuration.GetConnectionString("Catalog")))
            .AddMediatR(typeof(Program).Assembly);
    }

    private static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .Configure<AdminOptions>(configuration.GetSection(AdminOptions.SectionName))
            .Configure<TrainingOptions>(configuration.GetSection(TrainingOptions.SectionName));
    }

}
