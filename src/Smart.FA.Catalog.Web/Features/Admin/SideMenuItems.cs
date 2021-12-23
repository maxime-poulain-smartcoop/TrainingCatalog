using Ardalis.SmartEnum;

namespace Smart.FA.Catalog.Web.Features.Admin;

public class SideMenuItem : SmartEnum<SideMenuItem>
{
    public string Href { get; }

    //TODO use translation key for value.
    public static readonly SideMenuItem MyProfile   = new("My trainer Profile", 1, "");
    public static readonly SideMenuItem MyTrainings = new("My trainings", 2, "/admin/training/List");

    private SideMenuItem(string name, int value, string href) : base(name, value)
    {
        Href = href;
    }
}
