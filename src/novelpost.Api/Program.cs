using Microsoft.EntityFrameworkCore;
using novelpost.Api.Middleware;
using novelpost.Application;
using novelpost.Infrastructure;
using novelpost.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(o => o.UseSqlite(builder.Configuration.GetValue<string>("Database:ConnectionString")));

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(policy =>
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000"));
});

builder.Services.AddScoped<ErrorHandlingMiddleware>();

var app = builder.Build();

app.UseCors();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();
app.MapGet("/", () => "Hello World!");

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<DataContext>();
await Seed.SeedData(context);

app.Run();
