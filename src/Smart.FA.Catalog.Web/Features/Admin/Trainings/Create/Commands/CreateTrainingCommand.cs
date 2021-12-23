using MediatR;

namespace Smart.FA.Catalog.Web.Features.Admin.Trainings.Create.Commands;

public record CreateTrainingCommand : IRequest<int>
{
    public string? Title { get; set; }

    public List<int>?  AudienceTypeIds { get; set; }

    public List<int>? TrainingTypeIds { get; set; }

    public List<int>? TargetAudienceIds { get; set; }

    public string? Goal { get; set; }

    public string? PedagogicalProcedures { get; set; }

    public string? Address { get; set; }

}
