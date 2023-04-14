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


        #region ParallelsClassInput

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

        #endregion


        var pupils = new List<Pupil>();
        var pupilId = 1u;
        for (int i = 1; i <= 11; i++)
        {
            for (int j = 1; j <= 4; j++)
            {
                var pupil = new Pupil()
                {
                    Id = pupilId,
                    Name = Faker.Name.First(),
                    SurName = Faker.Name.Last(),
                    MiddleName = Faker.Name.Middle(),
                    IsDeleted = false,
                    ClassId = (uint)i
                };
                pupils.Add(pupil);
                pupilId++;
            }
        }
        modelBuilder.Entity<Pupil>().HasData(pupils);

        var teachers = new List<Teacher>();
        
        for (uint i = 1; i <= 1000; i++)
        {
            teachers.Add(new Teacher
            {
                Id = i,
                Name = Faker.Name.First(),
                SurName = Faker.Name.Last(),
                MiddleName = Faker.Name.Middle(),
                Comment = Faker.Phone.Number(),
            });
        }
        modelBuilder.Entity<Teacher>().HasData(teachers);
    }
}