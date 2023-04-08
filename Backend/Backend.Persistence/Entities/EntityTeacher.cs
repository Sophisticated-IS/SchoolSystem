using Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistence.Entities;

internal sealed class EntityTeacher : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).HasMaxLength(64);
        builder.Property(p => p.SurName).HasMaxLength(64);
        builder.Property(p=>p.MiddleName).HasMaxLength(64);
        builder.Property(p=>p.Comment).HasMaxLength(1024);
    }
}