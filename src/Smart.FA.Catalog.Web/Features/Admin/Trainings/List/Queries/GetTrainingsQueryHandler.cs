using MediatR;
using Microsoft.EntityFrameworkCore;
using Smart.Design.Razor.TagHelpers.Pill;
using Smart.FA.Catalog.Web.Domain.Enumerations;
using Smart.FA.Catalog.Web.Extensions;
using Smart.FA.Catalog.Web.Infrastructure.Data.Context;
using Smart.FA.Catalog.Web.Infrastructure.Data.Extensions;

namespace Smart.FA.Catalog.Web.Features.Admin.Trainings.List.Queries;

public class GetTrainingsQueryHandler : IRequestHandler<GetTrainingsQuery, QueryResponse>
{
    private readonly CatalogContext _catalogContext;

    public GetTrainingsQueryHandler(CatalogContext catalogContext)
    {
        _catalogContext = catalogContext;
    }

    public async Task<QueryResponse> Handle(GetTrainingsQuery request, CancellationToken cancellationToken)
    {
        var trainings = await _catalogContext
            .Training
            .Select(training => new { training.Status, training.TrainingDetail.Title, training.Topic })
            .Paginate(request.Page, request.Count)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        return new QueryResponse
        {
            Trainings = trainings.ConvertAll(training => new TrainingDto
            {
                Status     = TrainingStatus.FromValue(training.Status),
                PillStatus = PillStatusByTrainingStatus(TrainingStatus.FromValue(training.Status)),
                Title      = training.Title,
                Tags       = training.Topic.Select(topic => topic.Key).ToList()
            })
        };
    }

    private PillStatus PillStatusByTrainingStatus(TrainingStatus trainingStatus)
    {
        if (Equals(trainingStatus, TrainingStatus.PendingValidation))
        {
            return PillStatus.Danger;
        }

        if (Equals(trainingStatus, TrainingStatus.Validated))
        {
            return PillStatus.Success;
        }

        if (Equals(trainingStatus, TrainingStatus.Draft))
        {
            return PillStatus.Default;
        }

        return PillStatus.Default;
    }
}
