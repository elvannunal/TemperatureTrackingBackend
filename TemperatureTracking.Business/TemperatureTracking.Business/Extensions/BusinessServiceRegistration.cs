using Microsoft.Extensions.DependencyInjection;
using TemperatureTracking.Business.Services;
using TemperatureTracking.Core.Interfaces;

namespace TemperatureTracking.Business.Extensions;

public static class BusinessServiceRegistration
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        // Repository Kaydı
        services.AddScoped<ITemperatureService, TemperatureService>();
    }
}