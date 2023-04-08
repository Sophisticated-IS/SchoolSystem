using Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence.DbContext;

internal sealed class PgsqlContext : Microsoft.EntityFrameworkCore.DbContext
{

    public PgsqlContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //todo вынести бы в настройки приложения
        optionsBuilder.UseNpgsql("Host=localhost;Port=5436;Database=SchoolBackendDB;Username=postgres;Password=postgres;");
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
}