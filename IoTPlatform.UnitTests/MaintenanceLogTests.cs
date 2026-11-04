
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoTPlatform.Domain.Entities;

namespace IoTPlatform.UnitTests
{
    [TestClass]
    public class MaintenanceLogTests
    {
        //----------------------------------------create valid maintenance log-----------------------
        [TestMethod]
        public void Constructor_ValidLog_CreatesLog()
        {
            var log = new MaintenanceLog(
                1, 201, "Inspect badminton court sensor", "Alex"
            );

            Assert.AreEqual(1, log.Id);
            Assert.AreEqual(201, log.DeviceId);
            Assert.AreEqual("Inspect badminton court sensor", log.Description);
            Assert.AreEqual("Alex", log.Technician);
            Assert.IsFalse(log.IsCompleted);
        }

        //----------------------------------------reject invalid id-----------------------
        [TestMethod]
        public void Constructor_InvalidId_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                new MaintenanceLog(
                    0, 201, "Inspect court sensor", "Alex"
                );
            });
        }

        //----------------------------------------reject invalid device id-----------------------
        [TestMethod]
        public void Constructor_InvalidDeviceId_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                new MaintenanceLog(
                    2, 0, "Inspect court sensor", "Alex"
                );
            });
        }

        //----------------------------------------reject empty description-----------------------
        [TestMethod]
        public void Constructor_EmptyDescription_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                new MaintenanceLog(
                    3, 201, "", "Alex"
                );
            });
        }

        //----------------------------------------complete maintenance-----------------------
        [TestMethod]
        public void CompleteMaintenance_ValidLog_MarksCompleted()
        {
            var log = new MaintenanceLog(
                4, 202, "Calibrate shuttlecock speed sensor", "Jordan"
            );

            log.CompleteMaintenance();

            Assert.IsTrue(log.IsCompleted);
        }

        //----------------------------------------prevent duplicate completion-----------------------
        [TestMethod]
        public void CompleteMaintenance_AlreadyCompleted_ThrowsException()
        {
            var log = new MaintenanceLog(
                5, 203, "Repair court humidity monitor", "Taylor"
            );

            log.CompleteMaintenance();

            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                log.CompleteMaintenance();
            });
        }
    }
}

