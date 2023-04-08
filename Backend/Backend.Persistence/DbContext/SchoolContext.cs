﻿using Backend.Application;
using Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Parallel = Backend.Domain.Parallel;

namespace Backend.Persistence.DbContext;

public sealed class SchoolContext : Microsoft.EntityFrameworkCore.DbContext, ISchoolDbContext
{
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Pupil> Pupils { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<SchoolYear> SchoolYears { get; set; }
    public DbSet<Domain.Parallel> Parallel { get; set; }
    
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        
        modelBuilder.Entity<Class>().ToTable("Classes");
        modelBuilder.Entity<Domain.Parallel>().ToTable("Parallels");
        modelBuilder.Entity<SchoolYear>().ToTable("SchoolYears");
        modelBuilder.Entity<Teacher>().ToTable("Teachers");
        modelBuilder.Entity<Pupil>().ToTable("Pupils");
    }

    /// <summary>
    /// Устанвока зависимостей между табюлицами
    /// </summary>
    private void SetRelations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SchoolYear>().HasOne<Parallel>().WithMany();
        modelBuilder.Entity<Pupil>().HasOne<Class>().WithMany();
        modelBuilder.Entity<Class>().HasOne<Parallel>().WithMany();

        modelBuilder.Entity<Class>().HasMany(c=>c.Teachers).WithMany(t=>t.Classes)
                    .UsingEntity(j=>j.ToTable("TeachersClasses"));
    } 
}