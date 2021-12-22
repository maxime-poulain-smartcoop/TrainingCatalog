using Ardalis.SmartEnum;

namespace Smart.FA.Catalog.Web.Domain.Enumerations;

/// <summary>
/// Enumerates the different status that a training can have.
/// </summary>
public class TrainingStatus : SmartEnum<TrainingStatus>
{
    public static readonly TrainingStatus Draft = new(1, nameof(Draft));

    public static readonly TrainingStatus PendingValidation = new(2, nameof(PendingValidation));

    public static readonly TrainingStatus Validated = new(3, nameof(Validated));

    private TrainingStatus(int value, string name) : base(name, value)
    {
    }
}
