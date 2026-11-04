
using System.Collections.Generic;
using System.Threading.Tasks;
using IoTPlatform.Domain.Entities;

namespace IoTPlatform.Application.Repositories
{
    public interface IMaintenanceLogRepository
    {
        //----------------------------------------get all maintenance logs-----------------------
        Task<List<MaintenanceLog>> GetAllAsync();

        //----------------------------------------get maintenance by id-----------------------
        Task<MaintenanceLog?> GetByIdAsync(int id);

        //----------------------------------------get maintenance by device-----------------------
        Task<List<MaintenanceLog>> GetByDeviceIdAsync(int deviceId);

        //----------------------------------------add maintenance log-----------------------
        Task AddAsync(MaintenanceLog log);

        //----------------------------------------update maintenance log-----------------------
        Task UpdateAsync(MaintenanceLog log);

        //----------------------------------------delete maintenance log-----------------------
        Task DeleteAsync(int id);
    }
}

