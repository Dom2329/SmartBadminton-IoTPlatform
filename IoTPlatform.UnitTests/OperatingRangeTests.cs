
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoTPlatform.Domain.ValueObjects;

namespace IoTPlatform.UnitTests
{
    [TestClass]
    public class OperatingRangeTests
    {
        //----------------------------------------valid operating range-----------------------
        [TestMethod]
        public void Constructor_ValidRange_CreatesRange()
        {
            // arrange and act
            var range = new OperatingRange(15, 35);

            // assert
            Assert.AreEqual(15.0, range.MinValue);
            Assert.AreEqual(35.0, range.MaxValue);
        }

        //----------------------------------------reject negative minimum-----------------------
        [TestMethod]
        public void Constructor_NegativeMinimum_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                new OperatingRange(-5, 35);
            });
        }

        //----------------------------------------reject zero minimum-----------------------
        [TestMethod]
        public void Constructor_ZeroMinimum_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                new OperatingRange(0, 35);
            });
        }

        //----------------------------------------reject invalid maximum-----------------------
        [TestMethod]
        public void Constructor_MaximumBelowMinimum_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                new OperatingRange(35, 15);
            });
        }

        //----------------------------------------value inside range-----------------------
        [TestMethod]
        public void IsWithinRange_ValidValue_ReturnsTrue()
        {
            // arrange
            var range = new OperatingRange(15, 35);

            // act
            bool result = range.IsWithinRange(25);

            // assert
            Assert.IsTrue(result);
        }

        //----------------------------------------value outside range-----------------------
        [TestMethod]
        public void IsWithinRange_InvalidValue_ReturnsFalse()
        {
            // arrange
            var range = new OperatingRange(15, 35);

            // act
            bool result = range.IsWithinRange(50);

            // assert
            Assert.IsFalse(result);
        }
    }
}

