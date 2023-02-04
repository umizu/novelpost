using Microsoft.EntityFrameworkCore;
using novelpost.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(o => o.UseSqlite(builder.Configuration.GetValue<string>("Database:ConnectionString")));

builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(policy =>
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000"));
});

var app = builder.Build();

app.UseCors();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<DataContext>();
await Seed.SeedData(context);

app.Run();
