using Microsoft.AspNetCore.SignalR;
using TemperatureTracking.API.Hubs;
using TemperatureTracking.Core.Entities;
using TemperatureTracking.Core.Interfaces;

namespace TemperatureTracking.API.Workers;
public class TemperatureWorker : BackgroundService
{
    private readonly IHubContext<TemperatureHub> _hubContext;
    private readonly IServiceProvider _serviceProvider;

    public TemperatureWorker(IHubContext<TemperatureHub> hubContext, IServiceProvider serviceProvider)
    {
        _hubContext = hubContext;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                // Concrete sınıflarımızı çağırıyoruz
                var tempService = scope.ServiceProvider.GetRequiredService<ITemperatureService>();
                var alarmRepo = scope.ServiceProvider.GetRequiredService<IAlarmRepository>();

                //  Rastgele sıcaklık üret
                int currentTemp = tempService.GenerateRandomValue();

                //  SignalR ile oluşturulan veriyi frontend e yolla
                await _hubContext.Clients.All.SendAsync("ReceiveTemperature", currentTemp, stoppingToken);

                // derece kontrolü yap ve gerekirse DB'ye yaz
                if (tempService.IsCritical(currentTemp))
                {
                    await alarmRepo.SaveAlarmAsync(new AlarmLog
                    {
                        Temperature = currentTemp,
                        CreatedAt = DateTime.UtcNow,
                        Message = $"Kritik Seviye: {currentTemp}°C"
                    });
                }
            }

            // her 5 saniye de bir çalış
            await Task.Delay(5000, stoppingToken);
        }
    }
}