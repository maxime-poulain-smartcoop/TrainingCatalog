namespace Smart.FA.Catalog.Web.Domain.Entities;

public partial class Topic
{
    public Topic()
    {
        Training = new HashSet<Training>();
    }

    public int Id { get; set; }
    public string Key { get; set; } = null!;

    public virtual ICollection<Training> Training { get; set; }
}
