using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smart.FA.Catalog.Web.Features.Admin.Trainings.Create.Commands;
using Smart.FA.Catalog.Web.Features.Admin.Trainings.Create.Queries;

namespace Smart.FA.Catalog.Web.Features.Admin.Trainings.Create;

public class CreateModel : AdminPage
{
    public QueryResponse? PageData { get; set; }

    [BindProperty]
    public CreateTrainingCommand TrainingCreationTrainingCommand { get; set; } = null!;

    public CreateModel(IMediator mediator) : base(mediator)
    {
    }

    private async Task InitAsync()
    {
        SetSideMenuItem();
        PageData = await Mediator.Send(new Query()).ConfigureAwait(false);
    }

    public async Task OnGet()
    {
        await InitAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return RedirectToPage();
        }

        var success = await Mediator.Send(TrainingCreationTrainingCommand!).ConfigureAwait(false) > 0;
        if (success)
        {
            return RedirectToPage("/Admin/Trainings/List/List");
        }

        await InitAsync();
        return Page();
    }

    protected override SideMenuItem GetSideMenuItem()
    {
        return SideMenuItem.MyTrainings;
    }
}
