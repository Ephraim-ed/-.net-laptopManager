using Microsoft.OpenApi.Any;

namespace LaptopManager.Models.Entities
{
    public class LaptopInfo
    {
        public Guid Id{ get; set; }

        public int SerialNumber { get; set; }
        public string? Model { get; set; }
        public required string CurrentUser { get; set; }
    }
}
 