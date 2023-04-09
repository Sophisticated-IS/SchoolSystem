using Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistence.Entities;

internal sealed class EntitySchoolYear : IEntityTypeConfiguration<SchoolYear>
{
    public void Configure(EntityTypeBuilder<SchoolYear> builder)
    {
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.HasIndex(p=>p.Year).IsUnique(true);
    }
}