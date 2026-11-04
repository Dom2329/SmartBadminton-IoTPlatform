
using System.Collections.Generic;
using System.Threading.Tasks;
using IoTPlatform.Application.DTOs;

namespace IoTPlatform.Application.Services
{
    public interface IDeviceAssetService
    {
        //----------------------------------------get all devices-----------------------
        Task<List<DeviceAssetDto>> GetAllAsync();

        //----------------------------------------get device by id-----------------------
        Task<DeviceAssetDto?> GetByIdAsync(int id);

        //----------------------------------------add device-----------------------
        Task AddAsync(DeviceAssetDto device);

        //----------------------------------------activate device-----------------------
        Task ActivateAsync(int id);

        //----------------------------------------deactivate device-----------------------
        Task DeactivateAsync(int id);

        //----------------------------------------start maintenance-----------------------
        Task StartMaintenanceAsync(int id);

        //----------------------------------------finish maintenance-----------------------
        Task FinishMaintenanceAsync(int id);
    }
}

