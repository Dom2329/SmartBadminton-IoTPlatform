
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoTPlatform.Domain.Entities;

namespace IoTPlatform.UnitTests
{
    [TestClass]
    public class TelemetryMetricTests
    {
        //----------------------------------------create valid telemetry-----------------------
        [TestMethod]
        public void Constructor_ValidTelemetry_CreatesReading()
        {
            // arrange and act
            var reading = new TelemetryMetric(
                1, 201, "Court Temperature", 24.5, "C"
            );

            // assert
            Assert.AreEqual(1, reading.Id);
            Assert.AreEqual(201, reading.DeviceId);
            Assert.AreEqual("Court Temperature", reading.MetricName);
            Assert.AreEqual(24.5, reading.Value);
            Assert.AreEqual("C", reading.Unit);
        }

        //----------------------------------------reject invalid id-----------------------
        [TestMethod]
        public void Constructor_InvalidId_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                new TelemetryMetric(
                    0, 201, "Court Temperature", 24.5, "C"
                );
            });
        }

        //----------------------------------------reject invalid device id-----------------------
        [TestMethod]
        public void Constructor_InvalidDeviceId_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                new TelemetryMetric(
                    2, 0, "Court Temperature", 24.5, "C"
                );
            });
        }

        //----------------------------------------reject empty metric name-----------------------
        [TestMethod]
        public void Constructor_EmptyMetricName_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                new TelemetryMetric(
                    3, 201, "", 24.5, "C"
                );
            });
        }

        //----------------------------------------reject invalid value-----------------------
        [TestMethod]
        public void Constructor_NaNValue_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                new TelemetryMetric(
                    4, 202, "Shuttlecock Speed", double.NaN, "km/h"
                );
            });
        }

        //----------------------------------------reject empty unit-----------------------
        [TestMethod]
        public void Constructor_EmptyUnit_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                new TelemetryMetric(
                    5, 203, "Court Humidity", 55.0, ""
                );
            });
        }
    }
}
