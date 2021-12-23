using Ardalis.SmartEnum;

namespace Smart.FA.Catalog.Web.Features.Admin;

public class SideMenuItem : SmartEnum<SideMenuItem>
{
    //TODO use translation key for value.
    public static readonly SideMenuItem MyProfile   = new("My trainer Profile", 1);
    public static readonly SideMenuItem MyTrainings = new("My trainings", 2);

    private SideMenuItem(string name, int value) : base(name, value)
    {
    }
}
