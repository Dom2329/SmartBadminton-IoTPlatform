
using Microsoft.EntityFrameworkCore;
using IoTPlatform.Application.Repositories;
using IoTPlatform.Domain.Entities;
using IoTPlatform.Infrastructure.Data;

namespace IoTPlatform.Infrastructure.Repositories
{
    public class DeviceAssetRepository : IDeviceAssetRepository
    {
        private readonly IoTPlatformDbContext _context;

        //----------------------------------------constructor-----------------------
        public DeviceAssetRepository(IoTPlatformDbContext context)
        {
            _context = context;
        }

        //----------------------------------------get all devices-----------------------

        public async Task<List<DeviceAsset>> GetAllAsync()
        {
            return await _context.Devices.ToListAsync();
        }


        //----------------------------------------get device by id-----------------------
        public async Task<DeviceAsset?> GetByIdAsync(int id)
        {
            return await _context.Devices.FindAsync(id);
        }

        //----------------------------------------add device-----------------------
        public async Task AddAsync(DeviceAsset device)
        {
            await _context.Devices.AddAsync(device);
            await _context.SaveChangesAsync();
        }

        //----------------------------------------update device-----------------------
        public async Task UpdateAsync(DeviceAsset device)
        {
            _context.Devices.Update(device);
            await _context.SaveChangesAsync();
        }

        //----------------------------------------delete device-----------------------
        public async Task DeleteAsync(int id)
        {
            var device = await _context.Devices.FindAsync(id);

            if (device != null)
            {
                _context.Devices.Remove(device);
                await _context.SaveChangesAsync();
            }
        }
    }
}

