using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcces;

internal class ConfigureUser: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(u => u.Group)
            .WithMany(g => g.Interns)
            .HasForeignKey(u => u.GroupId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}