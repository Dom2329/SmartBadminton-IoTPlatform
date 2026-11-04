
using System;
using System.Text.RegularExpressions;
using IoTPlatform.Domain.Exceptions;
using IoTPlatform.Domain.ValueObjects;

namespace IoTPlatform.Domain.Entities
{
    public class DeviceAsset
    {
        //----------------------------------------variables-----------------------
        public int Id { get; private set; }
        public string SerialNumber { get; private set; }
        public string Name { get; private set; }
        public string Status { get; private set; }
        public OperatingRange Range { get; private set; }


        //----------------------------------------database constructor-----------------------
        private DeviceAsset()
        {
            SerialNumber = "";
            Name = "";
            Status = "";
            Range = null!;
        }


        //----------------------------------------constructor-----------------------
        public DeviceAsset(int id, string serialNumber, string name, OperatingRange range)
        {
            // check id
            if (id <= 0)
            {
                throw new DomainException("Invalid device ID");
            }

            // check serial number
            if (string.IsNullOrWhiteSpace(serialNumber) ||
                !Regex.IsMatch(serialNumber, @"^DEV-\d{5}$"))
            {
                throw new DomainException("Invalid serial number");
            }

            // check name
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("Device name cannot be empty");
            }

            // check range
            if (range == null)
            {
                throw new DomainException("Operating range is required");
            }

            Id = id;
            SerialNumber = serialNumber;
            Name = name;
            Range = range;
            Status = "Inactive";
        }

        //----------------------------------------activate method-----------------------
        public void Activate()
        {
            // check status
            if (Status != "Inactive")
            {
                throw new DomainException("Device cannot be activated");
            }

            Status = "Active";
        }

        //----------------------------------------deactivate method-----------------------
        public void Deactivate()
        {
            // check status
            if (Status != "Active")
            {
                throw new DomainException("Device cannot be deactivated");
            }

            Status = "Inactive";
        }

        //----------------------------------------maintenance method-----------------------
        public void StartMaintenance()
        {
            // check status
            if (Status != "Inactive")
            {
                throw new DomainException("Device must be inactive");
            }

            Status = "Maintenance";
        }

        //----------------------------------------finish maintenance method-----------------------
        public void FinishMaintenance()
        {
            // check status
            if (Status != "Maintenance")
            {
                throw new DomainException("Device is not in maintenance");
            }

            Status = "Inactive";
        }
    }
}
