namespace Smart.FA.Catalog.Web.Domain.Entities;

public partial class Training
{
    public Training()
    {
        AudienceType   = new HashSet<AudienceType>();
        TargetAudience = new HashSet<TargetAudience>();
        Topic          = new HashSet<Topic>();
        TrainingType   = new HashSet<TrainingType>();
    }

    public int Id { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public virtual Address Address { get; set; } = null!;
    public virtual TrainingDetail TrainingDetail { get; set; } = null!;

    public virtual ICollection<AudienceType> AudienceType { get; set; }
    public virtual ICollection<TargetAudience> TargetAudience { get; set; }
    public virtual ICollection<Topic> Topic { get; set; }
    public virtual ICollection<TrainingType> TrainingType { get; set; }
}
