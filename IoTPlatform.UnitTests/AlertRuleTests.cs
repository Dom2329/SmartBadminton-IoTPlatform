
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoTPlatform.Domain.Entities;

namespace IoTPlatform.UnitTests
{
    [TestClass]
    public class AlertRuleTests
    {
        //----------------------------------------create valid alert rule-----------------------
        [TestMethod]
        public void Constructor_ValidRule_CreatesRule()
        {
            var rule = new AlertRule(
                1, 201, "Court Temperature", 15, 35
            );

            Assert.AreEqual(1, rule.Id);
            Assert.AreEqual(201, rule.DeviceId);
            Assert.AreEqual(15.0, rule.MinValue);
            Assert.AreEqual(35.0, rule.MaxValue);
        }

        //----------------------------------------reject invalid range-----------------------
        [TestMethod]
        public void Constructor_InvalidRange_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                new AlertRule(
                    2, 201, "Court Temperature", 35, 15
                );
            });
        }

        //----------------------------------------detect high temperature-----------------------
        [TestMethod]
        public void CheckAlert_HighTemperature_ReturnsTrue()
        {
            var rule = new AlertRule(
                3, 201, "Court Temperature", 15, 35
            );

            bool result = rule.CheckAlert(40);

            Assert.IsTrue(result);
        }

        //----------------------------------------detect low temperature-----------------------
        [TestMethod]
        public void CheckAlert_LowTemperature_ReturnsTrue()
        {
            var rule = new AlertRule(
                4, 201, "Court Temperature", 15, 35
            );

            bool result = rule.CheckAlert(10);

            Assert.IsTrue(result);
        }

        //----------------------------------------normal temperature-----------------------
        [TestMethod]
        public void CheckAlert_NormalTemperature_ReturnsFalse()
        {
            var rule = new AlertRule(
                5, 201, "Court Temperature", 15, 35
            );

            bool result = rule.CheckAlert(25);

            Assert.IsFalse(result);
        }

        //----------------------------------------disabled alert rule-----------------------
        [TestMethod]
        public void CheckAlert_DisabledRule_ReturnsFalse()
        {
            var rule = new AlertRule(
                6, 202, "Shuttlecock Speed", 10, 500
            );

            rule.Deactivate();

            bool result = rule.CheckAlert(550);

            Assert.IsFalse(result);
        }
    }
}

