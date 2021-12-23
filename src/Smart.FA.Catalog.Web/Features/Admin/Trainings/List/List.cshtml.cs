using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Smart.FA.Catalog.Web.Domain.Options;
using Smart.FA.Catalog.Web.Features.Admin.Trainings.List.Queries;

namespace Smart.FA.Catalog.Web.Features.Admin.Trainings.List;

public class ListModel : AdminPage
{
    private readonly AdminOptions _adminOptions;

    [BindProperty(SupportsGet = true)]
    public int CurrentPage { get; set; } = 1;

    public List<TrainingDto>? Trainings { get; set; }
    public int NumberOfTrainingPerPage { get; set; }

    public ListModel(IMediator mediator, IOptions<AdminOptions> adminOptions) : base(mediator)
    {
        _adminOptions           = adminOptions.Value ?? throw new ArgumentNullException(nameof(adminOptions));
        NumberOfTrainingPerPage = _adminOptions.Training?.NumberOfTrainingsListed ?? throw new NullReferenceException();
    }

    public async Task<IActionResult> OnGetAsync()
    {
        SetSideMenuItem();
        if (CurrentPage < 0)
        {
            return RedirectToCurrentPageOne();
        }

        var response = await Mediator.Send(new GetTrainingsQuery(CurrentPage, _adminOptions.Training!.NumberOfTrainingsListed)).ConfigureAwait(false);
        Trainings    = response.Trainings;

        // If CurrentPage returns no result, redirect to the index 1.
        return Trainings?.Count == 0 ? RedirectToCurrentPageOne() : Page();
    }

    private IActionResult RedirectToCurrentPageOne()
    {
        return RedirectToPage(new
        {
            CurrentPage = 1
        });
    }

    protected override SideMenuItem GetSideMenuItem() => SideMenuItem.MyTrainings;
}
