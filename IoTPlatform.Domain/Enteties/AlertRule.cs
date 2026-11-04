
using System;

namespace IoTPlatform.Domain.Entities
{
    public class AlertRule
    {
        //----------------------------------------variables-----------------------
        public int Id { get; private set; }
        public int DeviceId { get; private set; }
        public string MetricName { get; private set; }
        public double MinValue { get; private set; }
        public double MaxValue { get; private set; }
        public bool IsActive { get; private set; }

        //----------------------------------------constructor-----------------------
        public AlertRule(int id, int deviceId, string metricName, double minValue, double maxValue)
        {
            // check id
            if (id <= 0)
            {
                throw new ArgumentException("Invalid alert ID");
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

            // check limits
            if (double.IsNaN(minValue) || double.IsInfinity(minValue) ||
                double.IsNaN(maxValue) || double.IsInfinity(maxValue) ||
                minValue <= 0 || maxValue <= minValue)
            {
                throw new ArgumentException("Invalid operating limits");
            }

            Id = id;
            DeviceId = deviceId;
            MetricName = metricName;
            MinValue = minValue;
            MaxValue = maxValue;
            IsActive = true;
        }

        //----------------------------------------check alert method-----------------------
        public bool CheckAlert(double value)
        {
            // check reading
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentException("Invalid reading");
            }

            // check limits
            if (IsActive && (value < MinValue || value > MaxValue))
            {
                return true;
            }

            return false;
        }

        //----------------------------------------activate method-----------------------
        public void Activate()
        {
            IsActive = true;
        }

        //----------------------------------------deactivate method-----------------------
        public void Deactivate()
        {
            IsActive = false;
        }
    }
}

