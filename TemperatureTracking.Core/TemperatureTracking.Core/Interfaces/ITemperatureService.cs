namespace TemperatureTracking.Core.Interfaces;

public interface ITemperatureService
{
    int GenerateRandomValue();
    bool IsCritical(int value);
}