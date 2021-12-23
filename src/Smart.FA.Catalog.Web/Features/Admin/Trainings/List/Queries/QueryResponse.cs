using Smart.Design.Razor.TagHelpers.Pill;
using Smart.FA.Catalog.Web.Domain.Enumerations;

namespace Smart.FA.Catalog.Web.Features.Admin.Trainings.List.Queries;

public record QueryResponse
{
    public List<TrainingDto>? Trainings { get; set; }
}

public record TrainingDto // Could be named TrainingViewModel actually.
{
    public string? Title { get; set; }

    public List<string>? Tags { get; set; }

    public TrainingStatus? Status { get; set; }

    public PillStatus PillStatus { get; set; }

    public string StatusDisplayName => Display();

    private string Display()
    {
        if (Equals(Status, TrainingStatus.Draft))
            return "Draft";

        if (Equals(Status, TrainingStatus.PendingValidation))
            return "En attente de validation";

        if (Equals(Status, TrainingStatus.Validated))
            return "Validé";

        return string.Empty;
    }
}
