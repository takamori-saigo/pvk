using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcces;

internal class ConfigureTaskEvaluations: IEntityTypeConfiguration<TaskEvaluation>
{
    public void Configure(EntityTypeBuilder<TaskEvaluation> builder)
    {
        builder.HasOne(e => e.Task)
            .WithMany(t => t.Evaluations)
            .HasForeignKey(e => e.TaskId);

        builder.HasOne(e => e.Intern)
            .WithMany(u => u.TaskEvaluationsReceived)
            .HasForeignKey(e => e.InternId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Manager)
            .WithMany(u => u.TaskEvaluationsGiven)
            .HasForeignKey(e => e.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}