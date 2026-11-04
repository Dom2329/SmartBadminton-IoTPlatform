
using System.Collections.Generic;
using System.Threading.Tasks;
using IoTPlatform.Domain.Entities;

namespace IoTPlatform.Application.Repositories
{
    public interface IDeviceAssetRepository
    {
        //----------------------------------------get all devices-----------------------
        Task<List<DeviceAsset>> GetAllAsync();

        //----------------------------------------get device by id-----------------------
        Task<DeviceAsset?> GetByIdAsync(int id);

        //----------------------------------------add device-----------------------
        Task AddAsync(DeviceAsset device);

        //----------------------------------------update device-----------------------
        Task UpdateAsync(DeviceAsset device);

        //----------------------------------------delete device-----------------------
        Task DeleteAsync(int id);
    }
}

