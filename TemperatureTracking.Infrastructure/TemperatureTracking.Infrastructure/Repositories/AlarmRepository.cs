using Microsoft.EntityFrameworkCore;
using TemperatureTracking.Core.Entities;
using TemperatureTracking.Core.Interfaces;
using TemperatureTracking.Infrastructure.Data;

namespace TemperatureTracking.Infrastructure.Repositories;

public class AlarmRepository: IAlarmRepository
{
    private readonly AppDbContext _context;   
    
    public AlarmRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task SaveAlarmAsync(AlarmLog log)
    {
        await _context.AlarmLogs.AddAsync(log);
        await _context.SaveChangesAsync();
    }

    public async Task<List<AlarmLog>> GetAllAlarmsAsync()
    {
        return await _context.AlarmLogs
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();    
    }
}