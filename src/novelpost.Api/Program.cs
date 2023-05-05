using novelpost.Api;
using novelpost.Application;
using novelpost.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration, builder.Host);

var app = builder.Build();

app.UseExceptionHandler("/error");
app.MapControllers();

// using var scope = app.Services.CreateScope();
// var context = scope.ServiceProvider.GetRequiredService<DataContext>();
// await Seed.SeedData(context);

app.Run();
