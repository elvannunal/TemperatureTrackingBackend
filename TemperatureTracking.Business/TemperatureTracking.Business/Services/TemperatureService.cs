using Microsoft.Extensions.Configuration;
using TemperatureTracking.Core.Interfaces;

namespace TemperatureTracking.Business.Services;

public class TemperatureService:ITemperatureService
{
    private readonly int _criticalThreshold;

    public TemperatureService(IConfiguration configuration )
    {
        _criticalThreshold = configuration.GetValue<int>("TemperatureSettings:CriticalThreshold", 80);
    }

    public int GenerateRandomValue()
    {
        return new Random().Next(20, 101);
    }

    public bool IsCritical(int value)
    {
        return value > _criticalThreshold;
    }
}