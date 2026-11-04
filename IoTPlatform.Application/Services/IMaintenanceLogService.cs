
using System.Collections.Generic;
using System.Threading.Tasks;
using IoTPlatform.Application.DTOs;

namespace IoTPlatform.Application.Services
{
    public interface IMaintenanceLogService
    {
        //----------------------------------------get all maintenance logs-----------------------
        Task<List<MaintenanceLogDto>> GetAllAsync();

        //----------------------------------------get maintenance by id-----------------------
        Task<MaintenanceLogDto?> GetByIdAsync(int id);

        //----------------------------------------get maintenance by device-----------------------
        Task<List<MaintenanceLogDto>> GetByDeviceIdAsync(int deviceId);

        //----------------------------------------add maintenance log-----------------------
        Task AddAsync(MaintenanceLogDto log);

        //----------------------------------------update maintenance log-----------------------
        Task UpdateAsync(MaintenanceLogDto log);

        //----------------------------------------delete maintenance log-----------------------
        Task DeleteAsync(int id);

        //----------------------------------------complete maintenance-----------------------
        Task CompleteMaintenanceAsync(int id);
    }
}

