using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TemperatureTracking.Core.Interfaces;
using TemperatureTracking.Infrastructure.Data;
using TemperatureTracking.Infrastructure.Repositories;

namespace TemperatureTracking.Infrastructure.Extensions;

public static class InfrastructureServiceRegistration {
    
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {

        // DbContext ve PostgreSQL Yapılandırması
        var connectionString = configuration.GetConnectionString("PostgreConnection");
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));
        
        // Repository Kaydı
        services.AddScoped<IAlarmRepository, AlarmRepository>();

    }

}