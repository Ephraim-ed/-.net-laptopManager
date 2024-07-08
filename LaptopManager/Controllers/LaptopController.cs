using LaptopManager.Data;
using LaptopManager.Models;
using LaptopManager.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopManager.Controllers
{
    //localhost:xxxx/api/Laptop
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopInfoController : ControllerBase
    {
        private readonly LaptopContext dbContext;

        public LaptopInfoController(LaptopContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllLaptopInfo()
        {
            var allLaptopInfos = dbContext.LaptopInfos.ToList();

            return Ok(allLaptopInfos);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetLaptopInfoById(Guid id)
        {
            var LaptopInfo = dbContext.LaptopInfos.Find(id);

            if (LaptopInfo is null)
            {
                return NotFound();
            }
            return Ok(LaptopInfo);
        }

        [HttpPost]
        public IActionResult AddLaptopInfo(AddLaptopInfoDto addLaptopInfoDto)
        {
            var LaptopInfoEntity = new LaptopInfo()
            {
                SerialNumber = addLaptopInfoDto.SerialNumber,
                Model = addLaptopInfoDto.Model,
                CurrentUser = addLaptopInfoDto.CurrentUser,
            };

            dbContext.LaptopInfos.Add(LaptopInfoEntity);
            dbContext.SaveChanges();

            return Ok(LaptopInfoEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateLaptopInfo(Guid id, UpdateLaptopInfoDto updateLaptopInfoDto)
        {
            var LaptopInfo = dbContext.LaptopInfos.Find(id);
            if(LaptopInfo is null)
            {
                return NotFound();
            }

            LaptopInfo.SerialNumber = updateLaptopInfoDto.SerialNumber;
            LaptopInfo.Model = updateLaptopInfoDto.Model;
            LaptopInfo.CurrentUser = updateLaptopInfoDto.CurrentUser;

            dbContext.SaveChanges();

            return Ok(LaptopInfo);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteLaptopInfo(Guid id)
        {
            var LaptopInfo = dbContext.LaptopInfos.Find(id);
            if (LaptopInfo is null)
            {
                return NotFound();
            }

            dbContext.LaptopInfos.Remove(LaptopInfo);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
