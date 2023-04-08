using System.Reflection;
using Backend.Application;
using Backend.Application.Common.Mappings;
using Backend.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfiler(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfiler(typeof(ISchoolDbContext).Assembly));
});
builder.Services.AddMediatR((x)=>x.RegisterServicesFromAssembly(typeof(ISchoolDbContext).Assembly));

var connectionString = builder.Configuration
                              .GetSection("DefaultConnection").Value;
builder.Services.AddDbContext<ISchoolDbContext,SchoolContext>(options =>
{
    options.UseNpgsql(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();