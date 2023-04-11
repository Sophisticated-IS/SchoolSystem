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
    options.EnableSensitiveDataLogging();
    options.EnableDetailedErrors();
});

builder.Services.AddCors(options =>  
{  
    options.AddPolicy(name: "ReactCorsPolicy",  
        policy  =>  
        {  
            policy.WithOrigins("http://localhost:3000"); 
        });  
});  

var scope = builder.Services.BuildServiceProvider().CreateScope();
var schoolContext = scope.ServiceProvider.GetRequiredService<SchoolContext>();
schoolContext.Database.EnsureDeleted();
schoolContext.Database.EnsureCreated();



var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

// app.UseHttpsRedirection();
// app.UseAuthorization();
app.UseRouting();
app.UseCors("ReactCorsPolicy");
app.MapControllers();

app.Run();