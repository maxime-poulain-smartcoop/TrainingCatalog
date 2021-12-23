using MediatR;
using Microsoft.EntityFrameworkCore;
using Smart.FA.Catalog.Web.Domain.Dtos.Training;
using Smart.FA.Catalog.Web.Infrastructure.Data.Context;

namespace Smart.FA.Catalog.Web.Features.Admin.Trainings.Create.Queries;

public class QueryHandler : IRequestHandler<Query, QueryResponse>
{
    private readonly CatalogContext _catalogContext;

    public QueryHandler(CatalogContext catalogContext)
    {
        _catalogContext = catalogContext;
    }

    public async Task<QueryResponse> Handle(Query request, CancellationToken cancellationToken)
    {
        var trainingTypes = await _catalogContext.TrainingType
            .Select(type => new { type.Id, type.DescriptionKey, type.LabelKey })
            .ToListAsync(cancellationToken).ConfigureAwait(false);

        var targetAudiences = await _catalogContext.TargetAudience
            .Select(targetAudience => new { targetAudience.Id, targetAudience.DesriptionKey, targetAudience.LabelKey })
            .ToListAsync(cancellationToken).ConfigureAwait(false);

        var audienceTypes = await _catalogContext.AudienceType
            .Select(audienceType => new { audienceType.Id, audienceType.DescriptionKey, audienceType.LabelKey })
            .ToListAsync(cancellationToken).ConfigureAwait(false);

        return new QueryResponse()
        {
            TrainingTypes = trainingTypes.ConvertAll(trainingType => new TrainingTypeDto()
            {
                Id = trainingType.Id, Description = trainingType.DescriptionKey ?? string.Empty, Label = trainingType.LabelKey
            }),
            TargetAudiences = targetAudiences.ConvertAll(targetAudience => new TargetAudienceDto()
            {
                Id = targetAudience.Id, Description = targetAudience.DesriptionKey ?? string.Empty, Label = targetAudience.LabelKey
            }),
            AudienceTypes = audienceTypes.ConvertAll(audienceType => new AudienceTypeDto()
            {
                Id = audienceType.Id, Label = audienceType.LabelKey, Description = audienceType.DescriptionKey ?? string.Empty,
            })
        };
    }
}
