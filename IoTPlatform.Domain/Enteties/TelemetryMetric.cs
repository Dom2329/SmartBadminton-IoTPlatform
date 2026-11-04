
using System;

namespace IoTPlatform.Domain.Entities
{
    public class TelemetryMetric
    {
        //----------------------------------------variables-----------------------
        public int Id { get; private set; }
        public int DeviceId { get; private set; }
        public string MetricName { get; private set; }
        public double Value { get; private set; }
        public string Unit { get; private set; }
        public DateTime ReadingTime { get; private set; }

        //----------------------------------------constructor-----------------------
        public TelemetryMetric(int id, int deviceId, string metricName, double value, string unit)
        {
            // check id
            if (id <= 0)
            {
                throw new ArgumentException("Invalid metric ID");
            }

            // check device id
            if (deviceId <= 0)
            {
                throw new ArgumentException("Invalid device ID");
            }

            // check metric name
            if (string.IsNullOrWhiteSpace(metricName))
            {
                throw new ArgumentException("Metric name cannot be empty");
            }

            // check value
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentException("Invalid metric value");
            }

            // check unit
            if (string.IsNullOrWhiteSpace(unit))
            {
                throw new ArgumentException("Unit cannot be empty");
            }

            Id = id;
            DeviceId = deviceId;
            MetricName = metricName;
            Value = value;
            Unit = unit;
            ReadingTime = DateTime.UtcNow;
        }
    }
}
