using LaptopManager.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaptopManager.Data
{
    public class LaptopContext : DbContext
    {
        public LaptopContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LaptopInfo> LaptopInfos { get; set; }
    }
}
