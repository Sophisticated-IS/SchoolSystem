
using Serilog;
using Serilog.Events;
using Неверов_АнализУязвимостей_ПО.Models.DataBase;

using var db = new DataBaseContext();
db.InitializeDictionaries();
db.SaveChanges();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<DataBaseContext>();

Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .WriteTo.File("log.txt")
             .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
             .CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
