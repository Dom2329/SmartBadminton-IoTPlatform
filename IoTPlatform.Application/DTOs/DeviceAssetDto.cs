
namespace IoTPlatform.Application.DTOs
{
    public class DeviceAssetDto
    {
        //----------------------------------------variables-----------------------
        public int Id { get; set; }
        public string SerialNumber { get; set; } = "";
        public string Name { get; set; } = "";
        public string Status { get; set; } = "";
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
    }
}

