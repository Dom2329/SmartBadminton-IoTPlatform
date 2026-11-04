
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using IoTPlatform.Domain.Entities;
using IoTPlatform.Domain.ValueObjects;
using IoTPlatform.Infrastructure.Data;

namespace IoTPlatform.Infrastructure.Seed
{
    public class JsonSeedLoader
    {
        private readonly IoTPlatformDbContext _context;

        //----------------------------------------constructor-----------------------
        public JsonSeedLoader(IoTPlatformDbContext context)
        {
            _context = context;
        }

        //----------------------------------------load devices from json-----------------------
        public async Task LoadDevicesAsync(string filePath)
        {
            // check file exists
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("JSON file not found.", filePath);
            }

            // read json file
            string json = await File.ReadAllTextAsync(filePath);

            // convert json into device data
            var devices = JsonSerializer.Deserialize<List<DeviceSeedData>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (devices == null)
            {
                return;
            }

            // save new devices to database
            foreach (var item in devices)
            {
                bool exists = await _context.Devices
                    .AnyAsync(d => d.Id == item.Id ||
                                   d.SerialNumber == item.SerialNumber);

                if (!exists)
                {
                    var range = new OperatingRange(
                        item.MinValue,
                        item.MaxValue
                    );

                    var device = new DeviceAsset(
                        item.Id,
                        item.SerialNumber,
                        item.Name,
                        range
                    );

                    await _context.Devices.AddAsync(device);
                }
            }


            //----------------------------------------save devices with custom ids-----------------------
            await _context.Database.OpenConnectionAsync();

            try
            {
                // allow custom device ids
                await _context.Database.ExecuteSqlRawAsync(
                    "SET IDENTITY_INSERT dbo.Devices ON"
                );

                // save devices
                await _context.SaveChangesAsync();
            }
            finally
            {
                // restore automatic id generation
                await _context.Database.ExecuteSqlRawAsync(
                    "SET IDENTITY_INSERT dbo.Devices OFF"
                );

                await _context.Database.CloseConnectionAsync();
            }

        }

        //----------------------------------------json device data-----------------------
        private class DeviceSeedData
        {
            public int Id { get; set; }
            public string SerialNumber { get; set; } = "";
            public string Name { get; set; } = "";
            public double MinValue { get; set; }
            public double MaxValue { get; set; }
        }
    }
}

