
using System.Collections.Generic;
using System.Threading.Tasks;
using IoTPlatform.Application.DTOs;

namespace IoTPlatform.Application.Services
{
    public interface ITelemetryMetricService
    {
        //----------------------------------------get all readings-----------------------
        Task<List<TelemetryMetricDto>> GetAllAsync();

        //----------------------------------------get reading by id-----------------------
        Task<TelemetryMetricDto?> GetByIdAsync(int id);

        //----------------------------------------get readings by device-----------------------
        Task<List<TelemetryMetricDto>> GetByDeviceIdAsync(int deviceId);

        //----------------------------------------add reading-----------------------
        Task AddAsync(TelemetryMetricDto metric);

        //----------------------------------------delete reading-----------------------
        Task DeleteAsync(int id);
    }
}

