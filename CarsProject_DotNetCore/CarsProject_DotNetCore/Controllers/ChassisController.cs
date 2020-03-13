using System;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;

namespace CarsProject_DotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChassisController : Controller
    {
        private readonly IChassisService chassisService;

        public ChassisController(IChassisService chassisService)
        {
            this.chassisService = chassisService;
        }

        [HttpGet("{id}")]
        public ActionResult<ChassisDTO> Get(string id)
        {
            return this.chassisService.GetChassis(Guid.Parse(id));
        }

        [HttpPost]
        public void Post([FromBody] ChassisDTO chassisDTO)
        {
            this.chassisService.InsertChassis(chassisDTO);
        }

        [HttpPut]
        public void Put([FromBody] ChassisDTO chassisDTO)
        {
            this.chassisService.UpdateChassis(chassisDTO);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            this.chassisService.DeleteChassis(Guid.Parse(id));
        }
    }
}