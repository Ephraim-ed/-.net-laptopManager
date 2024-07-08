namespace LaptopManager.Models
{
    public class UpdateLaptopInfoDto
    {
        public int SerialNumber { get; set; }
        public string? Model { get; set; }
        public required string CurrentUser { get; set; }
    }
}
