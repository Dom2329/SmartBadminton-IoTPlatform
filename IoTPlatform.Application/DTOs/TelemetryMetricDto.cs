
using System;

namespace IoTPlatform.Application.DTOs
{
    public class TelemetryMetricDto
    {
        //----------------------------------------variables-----------------------
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string MetricName { get; set; } = "";
        public double Value { get; set; }
        public string Unit { get; set; } = "";
        public DateTime ReadingTime { get; set; }
    }
}

