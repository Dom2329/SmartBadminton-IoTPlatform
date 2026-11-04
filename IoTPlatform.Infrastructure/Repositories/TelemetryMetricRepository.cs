
using Microsoft.EntityFrameworkCore;
using IoTPlatform.Application.Repositories;
using IoTPlatform.Domain.Entities;
using IoTPlatform.Infrastructure.Data;

namespace IoTPlatform.Infrastructure.Repositories
{
    public class TelemetryMetricRepository : ITelemetryMetricRepository
    {
        private readonly IoTPlatformDbContext _context;

        //----------------------------------------constructor-----------------------
        public TelemetryMetricRepository(IoTPlatformDbContext context)
        {
            _context = context;
        }

        //----------------------------------------get all telemetry-----------------------
        public async Task<List<TelemetryMetric>> GetAllAsync()
        {
            return await _context.TelemetryMetrics.ToListAsync();
        }

        //----------------------------------------get telemetry by id-----------------------
        public async Task<TelemetryMetric?> GetByIdAsync(int id)
        {
            return await _context.TelemetryMetrics.FindAsync(id);
        }

        //----------------------------------------get telemetry by device id-----------------------
        public async Task<List<TelemetryMetric>> GetByDeviceIdAsync(int deviceId)
        {
            return await _context.TelemetryMetrics
                .Where(t => t.DeviceId == deviceId)
                .ToListAsync();
        }

        //----------------------------------------add telemetry-----------------------
        public async Task AddAsync(TelemetryMetric telemetry)
        {
            await _context.TelemetryMetrics.AddAsync(telemetry);
            await _context.SaveChangesAsync();
        }

        //----------------------------------------update telemetry-----------------------
        public async Task UpdateAsync(TelemetryMetric telemetry)
        {
            _context.TelemetryMetrics.Update(telemetry);
            await _context.SaveChangesAsync();
        }

        //----------------------------------------delete telemetry-----------------------
        public async Task DeleteAsync(int id)
        {
            var telemetry = await _context.TelemetryMetrics.FindAsync(id);

            if (telemetry != null)
            {
                _context.TelemetryMetrics.Remove(telemetry);
                await _context.SaveChangesAsync();
            }
        }
    }
}
