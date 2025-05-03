using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcces;

public class ConfigureGroup: IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasOne(g => g.Manager)
            .WithMany()
            .HasForeignKey(g => g.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}