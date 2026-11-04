
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoTPlatform.Domain.Entities;
using IoTPlatform.Domain.ValueObjects;
using IoTPlatform.Domain.Exceptions;

namespace IoTPlatform.UnitTests
{
    [TestClass]
    public class DeviceAssetTests
    {
        //----------------------------------------create valid device-----------------------
        [TestMethod]
        public void Constructor_ValidDevice_CreatesDevice()
        {
            // arrange
            var range = new OperatingRange(15, 35);

            // act
            var device = new DeviceAsset(
                201,
                "DEV-73184",
                "Badminton Court Temperature Sensor",
                range
            );

            // assert
            Assert.AreEqual(201, device.Id);
            Assert.AreEqual("DEV-73184", device.SerialNumber);
            Assert.AreEqual("Inactive", device.Status);
        }

        //----------------------------------------reject invalid serial number-----------------------
        [TestMethod]
        public void Constructor_InvalidSerial_ThrowsException()
        {
            // arrange
            var range = new OperatingRange(15, 35);

            // act and assert
            Assert.ThrowsException<DomainException>(() =>
            {
                new DeviceAsset(
                    202,
                    "BAD-123",
                    "Shuttlecock Speed Sensor",
                    range
                );
            });
        }

        //----------------------------------------activate device-----------------------
        [TestMethod]
        public void Activate_InactiveDevice_ChangesStatus()
        {
            // arrange
            var range = new OperatingRange(15, 35);

            var device = new DeviceAsset(
                203,
                "DEV-95316",
                "Court Humidity Monitor",
                range
            );

            // act
            device.Activate();

            // assert
            Assert.AreEqual("Active", device.Status);
        }

        //----------------------------------------deactivate device-----------------------
        [TestMethod]
        public void Deactivate_ActiveDevice_ChangesStatus()
        {
            // arrange
            var range = new OperatingRange(15, 35);

            var device = new DeviceAsset(
                204,
                "DEV-16427",
                "Court Lighting Sensor",
                range
            );

            // act
            device.Activate();
            device.Deactivate();

            // assert
            Assert.AreEqual("Inactive", device.Status);
        }

        //----------------------------------------start maintenance-----------------------
        [TestMethod]
        public void StartMaintenance_InactiveDevice_ChangesStatus()
        {
            // arrange
            var range = new OperatingRange(15, 35);

            var device = new DeviceAsset(
                205,
                "DEV-27538",
                "Racket String Tension Sensor",
                range
            );

            // act
            device.StartMaintenance();

            // assert
            Assert.AreEqual("Maintenance", device.Status);
        }
    }
}
