using System.Reflection;
using Backend.Application;
using Backend.Application.Common.Mappings;
using Backend.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Backend.WebApi;

internal static class ServiceInjectionExtensions
{
    
    public static string CurrentCorsPolicy = "ReactCorsPolicy";
    public static IServiceCollection AddDataBaseConfig(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration
                               .GetSection("DefaultConnection").Value;
        serviceCollection.AddDbContext<ISchoolDbContext,SchoolContext>(options =>
        {
            options.UseNpgsql(connectionString);
            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
        });
        
        return serviceCollection;
    }    
    public static IServiceCollection AddAutoMapperConfig(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfiler(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfiler(typeof(ISchoolDbContext).Assembly));
        });
        
        return serviceCollection;
    }  
    
    
    
    public static IServiceCollection AddMediatRConfig(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR((x)=>x.RegisterServicesFromAssembly(typeof(ISchoolDbContext).Assembly));
        return serviceCollection;
    }

    public static IServiceCollection AddCorsPolicyConfig(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddCors(options =>  
        {  
            options.AddPolicy(name: CurrentCorsPolicy,  
                policy  =>  
                {  
                    policy.WithOrigins("http://localhost:3000")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                    policy.SetIsOriginAllowed(s => true);
                });  
        });  
        
        return serviceCollection;
    }

    // } public static IServiceCollection Add(this IServiceCollection serviceCollection)
    // {
    //     return serviceCollection;
    // } 
}