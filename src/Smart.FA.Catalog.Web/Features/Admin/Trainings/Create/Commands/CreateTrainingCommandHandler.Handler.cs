using MediatR;
using Microsoft.EntityFrameworkCore;
using Smart.FA.Catalog.Web.Domain.Entities;
using Smart.FA.Catalog.Web.Infrastructure.Data.Context;

namespace Smart.FA.Catalog.Web.Features.Admin.Trainings.Create.Commands;


public class CreateTrainingCommandHandler : IRequestHandler<CreateTrainingCommand, int>
{
    private readonly CatalogContext _catalogContext;

    public CreateTrainingCommandHandler(CatalogContext catalogContext)
    {
        _catalogContext = catalogContext;
    }

    public async Task<int> Handle(CreateTrainingCommand request, CancellationToken cancellationToken)
    {
        request.TrainingTypeIds ??= new List<int>();
        request.TargetAudienceIds ??= new List<int>();
        request.AudienceTypeIds ??= new List<int>();

        var audienceTypes = await _catalogContext.AudienceType
            .Where(audienceType => request.AudienceTypeIds.Contains(audienceType.Id))
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        var trainingTypes = await _catalogContext.TrainingType
            .Where(audienceType => request.TrainingTypeIds.Contains(audienceType.Id))
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        var targetAudiences = await _catalogContext.TargetAudience
            .Where(targetAudience => request.TargetAudienceIds.Contains(targetAudience.Id))
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        var training = new Training()
        {
            AudienceType = audienceTypes,
            TargetAudience = targetAudiences,
            TrainingType = trainingTypes,
            TrainingDetail = new TrainingDetail()
            {
                Goal = request.Goal,
                Methodology = request.PedagogicalProcedures,
                Title = request.Title,
                Language = "FR"
            },
            Address = new Address()
            {
                Place = request.Address
            }
        };

        _catalogContext.Training.Add(training);
        return await _catalogContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }
}
