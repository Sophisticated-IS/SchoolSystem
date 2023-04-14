using System.Security.Claims;
using Backend.Persistence.DbContext;
using Backend.WebApi;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var host = builder.Host;
var services = builder.Services;
var configuration = builder.Configuration;


services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddAutoMapperConfig();
services.AddMediatRConfig();
services.AddCorsPolicyConfig();
services.AddDataBaseConfig(configuration);

var scope = services.BuildServiceProvider().CreateScope();
var schoolContext = scope.ServiceProvider.GetRequiredService<SchoolContext>();
schoolContext.Database.EnsureDeleted();
schoolContext.Database.EnsureCreated();
#region KeycloakAuth
host.ConfigureKeycloakConfigurationSource();
services.AddKeycloakAuthentication(configuration);

services.AddAuthorization(options =>
        {
            options.AddPolicy("RequireWorkspaces", builder =>
            {
                builder
                    .RequireResourceRoles("SchoolAdmin");
            });
        })
        .AddKeycloakAuthorization(configuration);

#endregion




var app = builder.Build();

app.MapControllers();


app.UseAuthentication()
   .UseAuthorization();

// // Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();



app.UseCors(ServiceInjectionExtensions.CurrentCorsPolicy);

app.MapGet("/workspaces", 
    (ClaimsPrincipal user) =>
    {
        // TokenValidationParameters.NameClaimType is overriden based on keycloak specific claim
        app.Logger.LogInformation("{@User}", user.Identity.Name);
    })
   
   .RequireAuthorization("RequireWorkspaces");

app.Run();