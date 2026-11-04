
namespace IoTPlatform.Application.DTOs
{
    public class AlertRuleDto
    {
        //----------------------------------------variables-----------------------
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string MetricName { get; set; } = "";
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public bool IsActive { get; set; }
    }
}

