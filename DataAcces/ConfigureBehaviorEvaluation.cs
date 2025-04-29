using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcces;

internal class ConfigureBehaviorEvaluation: IEntityTypeConfiguration<BehaviorEvaluation>
{
    public void Configure(EntityTypeBuilder<BehaviorEvaluation> builder)
    {
        builder.HasOne(e => e.Manager)
            .WithMany(u => u.BehaviorEvaluationsAsManager)
            .HasForeignKey(e => e.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Intern)
            .WithMany(u => u.BehaviorEvaluationsAsIntern)
            .HasForeignKey(e => e.InternId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}