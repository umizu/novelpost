using novelpost.Api;
using novelpost.Application;
using novelpost.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration, builder.Host);

var app = builder.Build();

app.UseExceptionHandler("/error");
app.MapControllers();

// using var scope = app.Services.CreateScope();
// var services = scope.ServiceProvider;
// var context = services.GetRequiredService<DataContext>();
// await Seed.SeedData(context);

app.Run();
