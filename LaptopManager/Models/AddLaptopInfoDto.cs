namespace LaptopManager.Models
{
    public class AddLaptopInfoDto
    {
        public int SerialNumber { get; set; }
        public string? Model { get; set; }
        public required string CurrentUser { get; set; }
    }
}
