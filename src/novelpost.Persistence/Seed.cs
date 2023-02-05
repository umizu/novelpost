using novelpost.Domain.Models;

namespace novelpost.Persistence;
public static class Seed
{
    public static async Task SeedData(DataContext context)
    {
        if (context.Activities.Any()) return;

        var activities = new List<Activity>
            {
                new Activity
                {
                    Id = Guid.NewGuid(),
                    Verb = "read",
                    Date = DateTime.Now,
                    Unit = "page",
                    Start = 1,
                    End = 10,
                    BookId = Guid.NewGuid()
                },
                new Activity
                {
                    Id = Guid.NewGuid(),
                    Verb = "read",
                    Date = DateTime.Now,
                    Unit = "page",
                    Start = 11,
                    End = 20,
                    BookId = Guid.NewGuid()
                },
                new Activity
                {
                    Id = Guid.NewGuid(),
                    Verb = "read",
                    Date = DateTime.Now,
                    Unit = "page",
                    Start = 21,
                    End = 30,
                    BookId = Guid.NewGuid()
                }
            };

        await context.Activities.AddRangeAsync(activities);
        await context.SaveChangesAsync();
    }
}
