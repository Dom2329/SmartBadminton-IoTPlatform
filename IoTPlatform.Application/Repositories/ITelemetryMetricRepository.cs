
using System.Collections.Generic;
using System.Threading.Tasks;
using IoTPlatform.Domain.Entities;

namespace IoTPlatform.Application.Repositories
{
    public interface ITelemetryMetricRepository
    {
        //----------------------------------------get all readings-----------------------
        Task<List<TelemetryMetric>> GetAllAsync();

        //----------------------------------------get reading by id-----------------------
        Task<TelemetryMetric?> GetByIdAsync(int id);

        //----------------------------------------get readings by device-----------------------
        Task<List<TelemetryMetric>> GetByDeviceIdAsync(int deviceId);

        //----------------------------------------add reading-----------------------
        Task AddAsync(TelemetryMetric metric);

        //----------------------------------------delete reading-----------------------
        Task DeleteAsync(int id);
    }
}

