
using System.Collections.Generic;
using System.Threading.Tasks;
using IoTPlatform.Application.DTOs;

namespace IoTPlatform.Application.Services
{
    public interface IAlertRuleService
    {
        //----------------------------------------get all alerts-----------------------
        Task<List<AlertRuleDto>> GetAllAsync();

        //----------------------------------------get alert by id-----------------------
        Task<AlertRuleDto?> GetByIdAsync(int id);

        //----------------------------------------get alerts by device-----------------------
        Task<List<AlertRuleDto>> GetByDeviceIdAsync(int deviceId);

        //----------------------------------------add alert-----------------------
        Task AddAsync(AlertRuleDto alert);

        //----------------------------------------update alert-----------------------
        Task UpdateAsync(AlertRuleDto alert);

        //----------------------------------------delete alert-----------------------
        Task DeleteAsync(int id);

        //----------------------------------------check alert-----------------------
        Task<bool> CheckAlertAsync(int alertId, double value);
    }
}

