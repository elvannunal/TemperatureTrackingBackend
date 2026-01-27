using Microsoft.AspNetCore.Mvc;
using TemperatureTracking.Core.Interfaces;

namespace TemperatureTracking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlarmsController: ControllerBase
{
    private readonly IAlarmRepository _repository;

    public AlarmsController(IAlarmRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAlarms()
    {
        var alarms= await _repository.GetAllAlarmsAsync();
        return Ok(alarms);
    }
}