using Microsoft.EntityFrameworkCore;
using Smart.FA.Catalog.Web.Domain.Entities;

namespace Smart.FA.Catalog.Web.Infrastructure.Data.Context;

public partial class CatalogContext : DbContext
{
    public CatalogContext()
    {
    }

    public CatalogContext(DbContextOptions<CatalogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Address { get; set; } = null!;
    public virtual DbSet<AudienceType> AudienceType { get; set; } = null!;
    public virtual DbSet<TargetAudience> TargetAudience { get; set; } = null!;
    public virtual DbSet<Topic> Topic { get; set; } = null!;
    public virtual DbSet<Training> Training { get; set; } = null!;
    public virtual DbSet<TrainingDetail> TrainingDetail { get; set; } = null!;
    public virtual DbSet<TrainingType> TrainingType { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Scaffolding:ConnectionString", "Data Source=(local);Initial Catalog=Smart.FA.Catalog.Sql;Integrated Security=true");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasIndex(e => e.TrainingId, "IX_Address_TrainingId")
                .IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("getutcdate()");

            entity.Property(e => e.DeletedAt).HasPrecision(0);

            entity.Property(e => e.ModifiedAt).HasPrecision(0);

            entity.Property(e => e.Place).HasMaxLength(50);

            entity.HasOne(d => d.Training)
                .WithOne(p => p.Address)
                .HasForeignKey<Address>(d => d.TrainingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_Training");
        });

        modelBuilder.Entity<AudienceType>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("getutcdate()");

            entity.Property(e => e.DeletedAt).HasPrecision(0);

            entity.Property(e => e.DescriptionKey)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.LabelKey)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedAt).HasPrecision(0);
        });

        modelBuilder.Entity<TargetAudience>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("getutcdate()");

            entity.Property(e => e.DeletedAt).HasPrecision(0);

            entity.Property(e => e.DesriptionKey)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.LabelKey)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedAt).HasPrecision(0);
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.Property(e => e.Key).HasMaxLength(35);
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("getutcdate()");

            entity.Property(e => e.DeletedAt).HasPrecision(0);

            entity.Property(e => e.ModifiedAt).HasPrecision(0);

            entity.Property(e => e.Status).HasDefaultValueSql("1");

            entity.HasMany(d => d.AudienceType)
                .WithMany(p => p.Training)
                .UsingEntity<Dictionary<string, object>>(
                    "AudienceTypeTraining",
                    l => l.HasOne<AudienceType>().WithMany().HasForeignKey("AudienceTypeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AudienceTypeTraining_AudienceType"),
                    r => r.HasOne<Training>().WithMany().HasForeignKey("TrainingId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AudienceTypeTraining_Training"),
                    j =>
                    {
                        j.HasKey("TrainingId", "AudienceTypeId");

                        j.ToTable("AudienceTypeTraining");

                        j.HasIndex(new[] { "AudienceTypeId" }, "IX_AudienceTypeTraining_AudienceId");

                        j.HasIndex(new[] { "TrainingId" }, "IX_AudienceTypeTraining_TrainingId");
                    });

            entity.HasMany(d => d.TargetAudience)
                .WithMany(p => p.Training)
                .UsingEntity<Dictionary<string, object>>(
                    "TargetAudienceTraining",
                    l => l.HasOne<TargetAudience>().WithMany().HasForeignKey("TargetAudienceId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TargetAudienceTraining_TargetAudieneId"),
                    r => r.HasOne<Training>().WithMany().HasForeignKey("TrainingId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TargetAudienceTraining_Training"),
                    j =>
                    {
                        j.HasKey("TrainingId", "TargetAudienceId");

                        j.ToTable("TargetAudienceTraining");

                        j.HasIndex(new[] { "TargetAudienceId" }, "IX_TargetAudienceTraining_TargetAudienceId");

                        j.HasIndex(new[] { "TrainingId" }, "IX_TargetAudienceTraining_TrainingId");
                    });

            entity.HasMany(d => d.Topic)
                .WithMany(p => p.Training)
                .UsingEntity<Dictionary<string, object>>(
                    "TrainingTopic",
                    l => l.HasOne<Topic>().WithMany().HasForeignKey("TopicId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TrainingTopic_Topic"),
                    r => r.HasOne<Training>().WithMany().HasForeignKey("TrainingId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TrainingTopic_Training"),
                    j =>
                    {
                        j.HasKey("TrainingId", "TopicId");

                        j.ToTable("TrainingTopic");

                        j.HasIndex(new[] { "TopicId" }, "IX_TrainingTopic_TrainingId_TopicId");

                        j.HasIndex(new[] { "TrainingId" }, "IX_TrainingTopic_TrainingId_TrainingId");
                    });

            entity.HasMany(d => d.TrainingType)
                .WithMany(p => p.Training)
                .UsingEntity<Dictionary<string, object>>(
                    "TrainingTypeTraining",
                    l => l.HasOne<TrainingType>().WithMany().HasForeignKey("TrainingTypeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TrainingTypeTraining_TrainingType"),
                    r => r.HasOne<Training>().WithMany().HasForeignKey("TrainingId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TrainingTypeTraining_Training"),
                    j =>
                    {
                        j.HasKey("TrainingId", "TrainingTypeId");

                        j.ToTable("TrainingTypeTraining");

                        j.HasIndex(new[] { "TrainingId" }, "IX_TrainingTypeTraining_TrainingId");

                        j.HasIndex(new[] { "TrainingTypeId" }, "IX_TrainingTypeTraining_TrainingTypeId");
                    });
        });

        modelBuilder.Entity<TrainingDetail>(entity =>
        {
            entity.HasIndex(e => e.TrainingId, "IX_TrainingDescription_TrainingId")
                .IsUnique();

            entity.Property(e => e.Goal).HasMaxLength(1024);

            entity.Property(e => e.Language)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.Property(e => e.Methodology).HasMaxLength(1024);

            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Training)
                .WithOne(p => p.TrainingDetail)
                .HasForeignKey<TrainingDetail>(d => d.TrainingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrainingDescription_Training");
        });

        modelBuilder.Entity<TrainingType>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("getutcdate()");

            entity.Property(e => e.DeletedAt).HasPrecision(0);

            entity.Property(e => e.DescriptionKey)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.LabelKey)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedAt).HasPrecision(0);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
