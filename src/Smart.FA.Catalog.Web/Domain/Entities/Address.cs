namespace Smart.FA.Catalog.Web.Domain.Entities;

public partial class Address
{
    public int Id { get; set; }
    public string Place { get; set; } = null!;
    public int TrainingId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public virtual Training Training { get; set; } = null!;
}
