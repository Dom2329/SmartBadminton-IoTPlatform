
using System;

namespace IoTPlatform.Application.DTOs
{
    public class MaintenanceLogDto
    {
        //----------------------------------------variables-----------------------
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string Description { get; set; } = "";
        public string Technician { get; set; } = "";
        public DateTime MaintenanceDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}

