
using System;

namespace IoTPlatform.Domain.Entities
{
    public class MaintenanceLog
    {
        //----------------------------------------variables-----------------------
        public int Id { get; private set; }
        public int DeviceId { get; private set; }
        public string Description { get; private set; }
        public string Technician { get; private set; }
        public DateTime MaintenanceDate { get; private set; }
        public bool IsCompleted { get; private set; }

        //----------------------------------------constructor-----------------------
        public MaintenanceLog(int id, int deviceId, string description, string technician)
        {
            // check id
            if (id <= 0)
            {
                throw new ArgumentException("Invalid maintenance ID");
            }

            // check device id
            if (deviceId <= 0)
            {
                throw new ArgumentException("Invalid device ID");
            }

            // check description
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be empty");
            }

            // check technician
            if (string.IsNullOrWhiteSpace(technician))
            {
                throw new ArgumentException("Technician cannot be empty");
            }

            Id = id;
            DeviceId = deviceId;
            Description = description;
            Technician = technician;
            MaintenanceDate = DateTime.UtcNow;
            IsCompleted = false;
        }

        //----------------------------------------complete maintenance method-----------------------
        public void CompleteMaintenance()
        {
            // check status
            if (IsCompleted == true)
            {
                throw new InvalidOperationException("Maintenance already completed");
            }

            IsCompleted = true;
        }
    }
}

