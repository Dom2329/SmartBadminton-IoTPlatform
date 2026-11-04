
using System;

namespace IoTPlatform.Domain.ValueObjects
{
    public class OperatingRange
    {
        //----------------------------------------variables-----------------------
        public double MinValue { get; }
        public double MaxValue { get; }


        //----------------------------------------database constructor-----------------------
        private OperatingRange()
        {
        }


        //----------------------------------------constructor-----------------------
        public OperatingRange(double minValue, double maxValue)
        {
            // check minimum
            if (double.IsNaN(minValue) || double.IsInfinity(minValue) || minValue <= 0)
            {
                throw new ArgumentException("Invalid minimum value");
            }

            // check maximum
            if (double.IsNaN(maxValue) || double.IsInfinity(maxValue) || maxValue <= minValue)
            {
                throw new ArgumentException("Invalid maximum value");
            }

            MinValue = minValue;
            MaxValue = maxValue;
        }

        //----------------------------------------check range method-----------------------
        public bool IsWithinRange(double value)
        {
            // check reading
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentException("Invalid reading");
            }

            // check limits
            if (value >= MinValue && value <= MaxValue)
            {
                return true;
            }

            return false;
        }
    }
}

