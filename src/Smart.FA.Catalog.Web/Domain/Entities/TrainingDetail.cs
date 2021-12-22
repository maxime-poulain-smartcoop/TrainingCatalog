namespace Smart.FA.Catalog.Web.Domain.Entities;

public partial class TrainingDetail
{
    public int Id { get; set; }
    public int TrainingId { get; set; }
    public string Title { get; set; } = null!;
    public string? Goal { get; set; }
    public string? Methodology { get; set; }
    public string Language { get; set; } = null!;

    public virtual Training Training { get; set; } = null!;
}
