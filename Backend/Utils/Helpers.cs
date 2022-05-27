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

    public int GetTotalPages()
    {
        int totalItemsPerPages = 0;

        Int32.TryParse(settings.TotalContactsByCompanyPerPage, out totalItemsPerPages);

        return totalItemsPerPages;
    }

}