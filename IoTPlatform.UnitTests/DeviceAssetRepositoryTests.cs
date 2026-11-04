
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoTPlatform.Domain.Entities;
using IoTPlatform.Domain.ValueObjects;
using IoTPlatform.Infrastructure.Data;
using IoTPlatform.Infrastructure.Repositories;

namespace IoTPlatform.UnitTests
{
    [TestClass]
    public class DeviceAssetRepositoryTests
    {
        //----------------------------------------create test database-----------------------
        private IoTPlatformDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<IoTPlatformDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new IoTPlatformDbContext(options);
        }

        //----------------------------------------add and retrieve device-----------------------
        [TestMethod]
        public async Task AddAsync_ValidDevice_SavesDevice()
        {
            // arrange
            using var context = CreateContext();
            var repository = new DeviceAssetRepository(context);

            var device = new DeviceAsset(
                201,
                "DEV-73184",
                "Badminton Court Temperature Sensor",
                new OperatingRange(15, 35)
            );

            // act
            await repository.AddAsync(device);
            var saved = await repository.GetByIdAsync(201);

            // assert
            Assert.IsNotNull(saved);
            Assert.AreEqual("DEV-73184", saved.SerialNumber);
        }

        //----------------------------------------get all devices-----------------------
        [TestMethod]
        public async Task GetAllAsync_DevicesExist_ReturnsDevices()
        {
            // arrange
            using var context = CreateContext();
            var repository = new DeviceAssetRepository(context);

            await repository.AddAsync(new DeviceAsset(
                201,
                "DEV-73184",
                "Court Temperature Sensor",
                new OperatingRange(15, 35)
            ));

            await repository.AddAsync(new DeviceAsset(
                202,
                "DEV-84295",
                "Shuttlecock Speed Sensor",
                new OperatingRange(10, 500)
            ));

            // act
            var devices = await repository.GetAllAsync();

            // assert
            Assert.AreEqual(2, devices.Count);
        }

        //----------------------------------------delete device-----------------------
        [TestMethod]
        public async Task DeleteAsync_ExistingDevice_RemovesDevice()
        {
            // arrange
            using var context = CreateContext();
            var repository = new DeviceAssetRepository(context);

            await repository.AddAsync(new DeviceAsset(
                203,
                "DEV-95316",
                "Court Humidity Monitor",
                new OperatingRange(20, 85)
            ));

            // act
            await repository.DeleteAsync(203);
            var deleted = await repository.GetByIdAsync(203);

            // assert
            Assert.IsNull(deleted);
        }
    }
}

