using novelpost.Application.Common.Interfaces.Services;

namespace novelpost.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
