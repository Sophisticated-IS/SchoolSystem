using Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence.DbContext;

internal sealed class PgsqlContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Pupil> Pupils { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<SchoolYear> SchoolYears { get; set; }
    public DbSet<Domain.Parallel> Parallel { get; set; }
    
    public PgsqlContext(DbContextOptions<PgsqlContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        
        modelBuilder.Entity<Class>().ToTable("Classes");
        modelBuilder.Entity<Domain.Parallel>().ToTable("Parallels");
        modelBuilder.Entity<SchoolYear>().ToTable("SchoolYears");
        modelBuilder.Entity<Teacher>().ToTable("Teachers");
        modelBuilder.Entity<Pupil>().ToTable("Pupils");
        modelBuilder.Entity<Class>().HasMany(c=>c.Teachers).WithMany(t=>t.Classes)
                    .UsingEntity(j=>j.ToTable("TeachersClasses"));
    }
}