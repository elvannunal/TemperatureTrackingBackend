using TemperatureTracking.Core.Entities;

namespace TemperatureTracking.Core.Interfaces;

public interface IAlarmRepository
{
    Task SaveAlarmAsync(AlarmLog log);
    Task<List<AlarmLog>> GetAllAlarmsAsync();
}