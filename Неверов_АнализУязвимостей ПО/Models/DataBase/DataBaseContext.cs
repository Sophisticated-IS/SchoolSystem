using Microsoft.EntityFrameworkCore;
using Serilog;
using Неверов_АнализУязвимостей_ПО.Models.DataBase.Schema;

namespace Неверов_АнализУязвимостей_ПО.Models.DataBase;

public sealed class DataBaseContext : DbContext
{
    public DbSet<Classes> Classes => Set<Classes>();
    public DbSet<ClassParallels> ClassParallels => Set<ClassParallels>();
    public DbSet<ParallelLevel> ParallelLevels => Set<ParallelLevel>();
    public DbSet<Pupils> Pupils => Set<Pupils>();
    public DbSet<SchoolYears> SchoolYears => Set<SchoolYears>();
    public DbSet<Teachers> Teachers => Set<Teachers>();


    public DataBaseContext()
    {
        try
        {
            Database.EnsureCreated();
            Log.Information("База данных успешно создана");
        }
        catch (Exception exception)
        {
            Log.Error(exception, "Не удалось создать базу данных");
        }
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5436;Database=SchoolScoresDB;Username=postgres;Password=postgres;");
    }

    public void InitializeDictionaries()
    {
       if (SchoolYears.Any()) return;
        
        SchoolYears.Add(new SchoolYears
        {
            SchoolYear = (uint)DateTime.Now.Year
        });

        var parallelLevel1 = new ParallelLevel()
        {
            Level = "начальная школа"
        };
        var parallelLevel2 = new ParallelLevel()
        {
            Level = "средняя школа"
        };
        
        var parallelLevel3 = new ParallelLevel()
        {
            Level = "старшая школа"
        };
        ParallelLevels.AddRange(new[] { parallelLevel1, parallelLevel2, parallelLevel3 });
        
        var letters = new char[]{'A','B','C','D'};
        for (int i = 1; i < 5; i++)
        {
            foreach (char c in letters)
            {
                ClassParallels.Add(new ClassParallels
                {
                    Parallel = $"{i}{c}",
                    ParallelLevelId = parallelLevel1
                });
            }
        }
        
        for (int i = 5; i < 9; i++)
        {
            foreach (char c in letters)
            {
                ClassParallels.Add(new ClassParallels
                {
                    Parallel = $"{i}{c}",
                    ParallelLevelId = parallelLevel2
                });
            }
        }
        
        for (int i = 9; i < 12; i++)
        {
            foreach (char c in letters)
            {
                ClassParallels.Add(new ClassParallels
                {
                    Parallel = $"{i}{c}",
                    ParallelLevelId = parallelLevel3
                });
            }
        }

        Log.Information("Справочники БД были проинициализированы");
    }
}