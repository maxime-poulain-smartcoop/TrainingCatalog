using MediatR;

namespace Smart.FA.Catalog.Web.Features.Admin.Trainings.List.Queries;

public record GetTrainingsQuery : IRequest<QueryResponse>
{
    public int Page { get; set; }

    public int Count { get; set; }

    public GetTrainingsQuery(int page, int count)
    {
        Page  = page;
        Count = count;
    }
}

