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
                    Unit = "Page",
                    Start = 1,
                    End = 10,
                    BookId = "978-3-16-148410-0"
                },
                new Activity
                {
                    Id = Guid.NewGuid(),
                    Verb = "read",
                    Date = DateTime.Now,
                    Unit = "Page",
                    Start = 11,
                    End = 20,
                    BookId = "978-3-16-148410-0"
                },
                new Activity
                {
                    Id = Guid.NewGuid(),
                    Verb = "read",
                    Date = DateTime.Now,
                    Unit = "pages",
                    Start = 21,
                    End = 30,
                    BookId = "978-3-16-148410-0"
                }
            };

        await context.Activities.AddRangeAsync(activities);
        await context.SaveChangesAsync();
    }
}
