using Smart.FA.Catalog.Web.Domain.Dtos.Training;

namespace Smart.FA.Catalog.Web.Features.Admin.Trainings.Create.Queries;

public class QueryResponse
{
    public List<TrainingTypeDto> TrainingTypes { get; set; } = new();

    public List<TargetAudienceDto> TargetAudiences { get; set; } = new();

    public List<AudienceTypeDto> AudienceTypes { get; set; } = new();
}
