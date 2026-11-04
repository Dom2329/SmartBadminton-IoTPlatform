
using System.Collections.Generic;
using System.Threading.Tasks;
using IoTPlatform.Domain.Entities;

namespace IoTPlatform.Application.Repositories
{
    public interface IAlertRuleRepository
    {
        //----------------------------------------get all alerts-----------------------
        Task<List<AlertRule>> GetAllAsync();

        //----------------------------------------get alert by id-----------------------
        Task<AlertRule?> GetByIdAsync(int id);

        //----------------------------------------get alerts by device-----------------------
        Task<List<AlertRule>> GetByDeviceIdAsync(int deviceId);

        //----------------------------------------add alert-----------------------
        Task AddAsync(AlertRule alert);

        //----------------------------------------update alert-----------------------
        Task UpdateAsync(AlertRule alert);

        //----------------------------------------delete alert-----------------------
        Task DeleteAsync(int id);
    }
}

