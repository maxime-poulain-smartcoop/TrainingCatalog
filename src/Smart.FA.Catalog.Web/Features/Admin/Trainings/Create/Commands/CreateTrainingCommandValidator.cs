using FluentValidation;
using Smart.FA.Catalog.Web.Extensions;
using Smart.FA.Catalog.Web.Infrastructure.Data.Context;
using Smart.FA.Catalog.Web.Infrastructure.Data.Extensions;

namespace Smart.FA.Catalog.Web.Features.Admin.Trainings.Create.Commands;

public class CreateTrainingCommandValidator : AbstractValidator<CreateTrainingCommand>
{
    public CreateTrainingCommandValidator(CatalogContext catalogContext)
    {
        RuleFor(command => command.Title)
            .NotEmpty()
            .WithMessage("Title cannot be empty");

        RuleFor(command => command.Address)
            .NotEmpty()
            .WithErrorCode("An address must be provided");

        RuleFor(command => command.PedagogicalProcedures)
            .NotEmpty()
            .WithMessage("Missing Pedagogical procedures");

        RuleFor(command => command.AudienceTypeIds)
            .MustAsync(async (_, audienceTypeIds, cancellationToken)
                => await catalogContext.AudienceType.ExistsAllAsync(audienceTypeIds, cancellationToken).ConfigureAwait(false))
            .When(command => command.AudienceTypeIds?.Count > 0);

        RuleFor(command => command.TargetAudienceIds)
            .MustAsync(async (_, audienceTypeIds, cancellationToken)
                => await catalogContext.TargetAudience.ExistsAllAsync(audienceTypeIds, cancellationToken).ConfigureAwait(false))
            .When(command => command.TargetAudienceIds?.Count > 0); ;

        RuleFor(command => command.TrainingTypeIds)
            .MustAsync(async (_, audienceTypeIds, cancellationToken)
                => await catalogContext.TrainingType.ExistsAllAsync(audienceTypeIds, cancellationToken).ConfigureAwait(false))
            .When(command => command.TrainingTypeIds?.Count > 0);
    }
}
