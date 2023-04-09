using Backend.Application;
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

        SeedData(modelBuilder);
    }
    

    private void SeedData(ModelBuilder modelBuilder)
    {
        var schoolYear = new SchoolYear
        {
            Id = 1,
            Year = 2023
        };
        modelBuilder.Entity<SchoolYear>().HasData(schoolYear);


        var parallels = new List<Parallel>();
        var classes = new List<Class>();
        for (uint i = 1, j = 0; i <= 11; i++)
        {
        
            var parallel = new Parallel
            {
                Id = i,
                Number = (byte)i,
                SchoolYearId = schoolYear.Id
            };
            parallels.Add(parallel);
        
        
            classes.Add(new()
            {
                Id = ++j,
                Letter = 'A',
                ParallelId = parallel.Id
            });
            classes.Add(
                new()
                {
                    Id = ++j,
                    Letter = 'B',
                    ParallelId = parallel.Id
                });
            classes.Add(
                new()
                {
                    Id = ++j,
                    Letter = 'C',
                    ParallelId = parallel.Id
                });
            classes.Add(
                new()
                {
                    Id = ++j,
                    Letter = 'D',
                    ParallelId = parallel.Id
                });
        }
        modelBuilder.Entity<Class>().HasData(classes);
        modelBuilder.Entity<Parallel>().HasData(parallels);

        var pupils = new List<Pupil>
        {
            new()
            {
                Id = 1,
                Name = "Иван",
                SurName = "Иванов",
                MiddleName = "Иванович",
                IsDeleted = false,
                ClassId = classes[0].Id
            },
            new()
            {
                Id = 2,
                Name = "Петр",
                SurName = "Петров",
                MiddleName = "Петрович",
                IsDeleted = false,
                ClassId = classes[1].Id
            },
            new()
            {
                Id = 3,
                Name = "Сергей",
                SurName = "Сергеев",
                MiddleName = "Сергеевич",
                IsDeleted = false,
                ClassId = classes[2].Id
            },
            new()
            {
                Id = 4,
                Name = "Антон",
                SurName = "Антонов",
                MiddleName = "Антонович",
                IsDeleted = false,
                ClassId = classes[2].Id
            },
            new()
            {
                Id = 5,
                Name = "Сергей",
                SurName = "Сергеев",
                MiddleName = "Сергеевич",
                IsDeleted = false,
                ClassId = classes[2].Id
            }
        };
        modelBuilder.Entity<Pupil>().HasData(pupils);
        
        var teachers = new List<Teacher>();
        teachers.Add(new Teacher
        {
            Id = 1,
            Name = "Иван",
            SurName = "Иванов",
            MiddleName = "Иванович",
            Comment = "Комментарий крутой",
        });
        teachers.Add(new()
        {
            Id = 2,
            Name = "Петр",
            SurName = "Петров",
            MiddleName = "Петрович",
            Comment = "Комментарий не очень",
        });
        
        teachers.Add(new()
        {
            Id = 3,
            Name = "Сергей",
            SurName = "Сергеев",
            MiddleName = "Сергеевич",
            Comment = "Комментарий просто есть",
        });
        
        teachers.Add(new()
        {
            Id = 4,
            Name = "Антон",
            SurName = "Бурунов",
            MiddleName = "Бахалович",
            Comment = "Комментарий прикольный",
        });
        
        teachers.Add(new Teacher
        {
            Id = 5,
            Name = "Максим",
            SurName = "Максимов",
            MiddleName = "Максимович",
            Comment = "Комментарий просто есть",
        });
        
        teachers.Add(new()
        {
            Id = 6,
            Name = "Александр",
            SurName = "Александров",
            MiddleName = "Александрович",
            Comment = "Комментарий просто есть",
        });
        
        teachers.Add(new Teacher
        {
            Id = 7,
            Name = "Бушка",
            SurName = "Пушка",
            MiddleName = "Пушкович",
            Comment = "Комментарий просто есть",
        });
        
        teachers.Add(new Teacher()
        {
            Id = 8,
            Name = "Дмитрий",
            SurName = "Дмитриев",
            MiddleName = "Дмитриевич",
            Comment = "Комментарий просто есть",
        });
        
        teachers.Add(new Teacher()
        {
            Id = 9,
            Name = "Милана",
            SurName = "Миланова",
            MiddleName = "Милановна",
            Comment = "Комментарий просто есть"
        });
        
        teachers.Add(new Teacher()
        {
            Id = 10,
            Name = "Евгений",
            SurName = "Евгениев",
            MiddleName = "Евгениевич",
            Comment = "Комментарий просто есть"
        });
        modelBuilder.Entity<Teacher>().HasData(teachers);
    }
}