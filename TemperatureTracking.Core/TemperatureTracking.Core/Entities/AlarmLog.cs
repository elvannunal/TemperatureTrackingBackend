namespace TemperatureTracking.Core.Entities;

public class AlarmLog
{
    public int Id { get; set; }
    public int Temperature { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Message { get; set; } = string.Empty;
}