
using Microsoft.EntityFrameworkCore;
using IoTPlatform.Application.Repositories;
using IoTPlatform.Domain.Entities;
using IoTPlatform.Infrastructure.Data;

namespace IoTPlatform.Infrastructure.Repositories
{
    public class MaintenanceLogRepository : IMaintenanceLogRepository
    {
        private readonly IoTPlatformDbContext _context;

        //----------------------------------------constructor-----------------------
        public MaintenanceLogRepository(IoTPlatformDbContext context)
        {
            _context = context;
        }

        //----------------------------------------get all maintenance logs-----------------------
        public async Task<List<MaintenanceLog>> GetAllAsync()
        {
            return await _context.MaintenanceLogs.ToListAsync();
        }

        //----------------------------------------get maintenance log by id-----------------------
        public async Task<MaintenanceLog?> GetByIdAsync(int id)
        {
            return await _context.MaintenanceLogs.FindAsync(id);
        }

        //----------------------------------------get logs by device id-----------------------
        public async Task<List<MaintenanceLog>> GetByDeviceIdAsync(int deviceId)
        {
            return await _context.MaintenanceLogs
                .Where(m => m.DeviceId == deviceId)
                .ToListAsync();
        }

        //----------------------------------------add maintenance log-----------------------
        public async Task AddAsync(MaintenanceLog log)
        {
            await _context.MaintenanceLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }

        //----------------------------------------update maintenance log-----------------------
        public async Task UpdateAsync(MaintenanceLog log)
        {
            _context.MaintenanceLogs.Update(log);
            await _context.SaveChangesAsync();
        }

        //----------------------------------------delete maintenance log-----------------------
        public async Task DeleteAsync(int id)
        {
            var log = await _context.MaintenanceLogs.FindAsync(id);

            if (log != null)
            {
                _context.MaintenanceLogs.Remove(log);
                await _context.SaveChangesAsync();
            }
        }
    }
}
