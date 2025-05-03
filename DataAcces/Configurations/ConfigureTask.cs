using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Core.Task;


namespace DataAccess
{
    public class ConfigureTask : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasOne(t => t.Group)
                .WithMany(g => g.Tasks)
                .HasForeignKey(t => t.GroupId);

            builder.HasOne(t => t.Creator)
                .WithMany(u => u.CreatedTasks)
                .HasForeignKey(t => t.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}