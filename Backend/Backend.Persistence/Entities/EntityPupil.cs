using Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistence.Entities;

internal sealed class EntityPupil : IEntityTypeConfiguration<Pupil>
{
    public void Configure(EntityTypeBuilder<Pupil> builder)
    {
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.HasOne(p=>p.Class).WithMany();
        builder.Property(p => p.Name).HasMaxLength(64);
        builder.Property(p => p.SurName).HasMaxLength(64);
        builder.Property(p => p.MiddleName).HasMaxLength(64);
        builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);
    }
}