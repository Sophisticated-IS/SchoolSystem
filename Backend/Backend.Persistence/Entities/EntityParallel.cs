using Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parallel = Backend.Domain.Parallel;

namespace Backend.Persistence.Entities;

internal sealed class EntityParallel : IEntityTypeConfiguration<Parallel>
{
    public void Configure(EntityTypeBuilder<Parallel> builder)
    {
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Number);
        builder.HasOne(p => p.SchoolYear).WithMany();
    }
}