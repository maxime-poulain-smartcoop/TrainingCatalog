using Smart.FA.Catalog.Web.Domain.Entities.Base;
using Smart.FA.Catalog.Web.Infrastructure.Data;

namespace Smart.FA.Catalog.Web.Domain.Entities;

public partial class AudienceType : Entity, IEntity<int>
{
    public AudienceType()
    {
        Training = new HashSet<Training>();
    }

    public int Id { get; set; }
    public string LabelKey { get; set; } = null!;
    public string? DescriptionKey { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Training> Training { get; set; }
}
