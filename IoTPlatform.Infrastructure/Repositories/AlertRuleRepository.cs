
using Microsoft.EntityFrameworkCore;
using IoTPlatform.Application.Repositories;
using IoTPlatform.Domain.Entities;
using IoTPlatform.Infrastructure.Data;

namespace IoTPlatform.Infrastructure.Repositories
{
    public class AlertRuleRepository : IAlertRuleRepository
    {
        private readonly IoTPlatformDbContext _context;

        //----------------------------------------constructor-----------------------
        public AlertRuleRepository(IoTPlatformDbContext context)
        {
            _context = context;
        }

        //----------------------------------------get all alert rules-----------------------
        public async Task<List<AlertRule>> GetAllAsync()
        {
            return await _context.AlertRules.ToListAsync();
        }

        //----------------------------------------get alert rule by id-----------------------
        public async Task<AlertRule?> GetByIdAsync(int id)
        {
            return await _context.AlertRules.FindAsync(id);
        }

        //----------------------------------------get alerts by device id-----------------------
        public async Task<List<AlertRule>> GetByDeviceIdAsync(int deviceId)
        {
            return await _context.AlertRules
                .Where(a => a.DeviceId == deviceId)
                .ToListAsync();
        }

        //----------------------------------------add alert rule-----------------------
        public async Task AddAsync(AlertRule alert)
        {
            await _context.AlertRules.AddAsync(alert);
            await _context.SaveChangesAsync();
        }

        //----------------------------------------update alert rule-----------------------
        public async Task UpdateAsync(AlertRule alert)
        {
            _context.AlertRules.Update(alert);
            await _context.SaveChangesAsync();
        }

        //----------------------------------------delete alert rule-----------------------
        public async Task DeleteAsync(int id)
        {
            var alert = await _context.AlertRules.FindAsync(id);

            if (alert != null)
            {
                _context.AlertRules.Remove(alert);
                await _context.SaveChangesAsync();
            }
        }
    }
}

