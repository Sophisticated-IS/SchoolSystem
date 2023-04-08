using Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application;

public interface ISchoolDbContext
{
    DbSet<Teacher> Teachers { get; set; }
    DbSet<Pupil> Pupils { get; set; }
    DbSet<Class> Classes { get; set; }
    DbSet<SchoolYear> SchoolYears { get; set; }
    DbSet<Domain.Parallel> Parallel { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}