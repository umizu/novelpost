using novelpost.Api;
using novelpost.Application;
using novelpost.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler("/error");

app.MapControllers();
app.MapGet("/", () => "Hello World!");

// using var scope = app.Services.CreateScope();
// var services = scope.ServiceProvider;
// var context = services.GetRequiredService<DataContext>();
// await Seed.SeedData(context);

app.Run();
