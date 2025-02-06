using Microsoft.AspNetCore.Builder;
using WebMarkupMin.AspNetCoreLatest;

namespace ClassLib.DependencyInjection;

public static class WebApplicationExtensions
{
    public static WebApplication UseMarkupOptimization(this WebApplication webApplication)
    {
        ArgumentNullException.ThrowIfNull(webApplication);

        webApplication.UseWebMarkupMin();

        return webApplication;
    }
}