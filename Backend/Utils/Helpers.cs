using System;
using Microsoft.Extensions.Options;

public class Helpers : IHelpers
{
    private readonly Settings settings;

    public Helpers(
            IOptions<Settings> _settings)
    {
        this.settings = _settings.Value;
    }

    public DateTime GetCurrentDateTime()
    {
        var timezone = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
        var currentDateTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, timezone);
        return currentDateTime;
    }

}