using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcces;

public class ConfigureEvaluation360: IEntityTypeConfiguration<Evaluation360>
{
    public void Configure(EntityTypeBuilder<Evaluation360> builder)
    {
        builder.HasOne(e => e.Evaluator)
            .WithMany(u => u.GivenEvaluations)
            .HasForeignKey(e => e.EvaluatorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Evaluated)
            .WithMany(u => u.ReceivedEvaluations)
            .HasForeignKey(e => e.EvaluatedId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}