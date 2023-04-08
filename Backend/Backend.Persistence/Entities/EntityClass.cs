using Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistence.Entities;

internal sealed class EntityClass : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.HasOne(p => p.Parallel).WithMany();
    }
}