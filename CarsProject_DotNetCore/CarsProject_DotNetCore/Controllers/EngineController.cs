using System;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;

namespace CarsProject_DotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : Controller
    {
        private readonly IEngineService engineService;

        public EngineController(IEngineService engineService)
        {
            this.engineService = engineService;
        }

        [HttpGet("{id}")]
        public ActionResult<EngineDTO> Get(string id)
        {
            var chassis = this.engineService.GetEngine(Guid.Parse(id));
            return chassis;
        }

        [HttpPost]
        public void Post([FromBody] EngineDTO engineDTO)
        {
            this.engineService.InsertEngine(engineDTO);
        }

        [HttpPut]
        public void Put([FromBody] EngineDTO engineDTO)
        {
            this.engineService.UpdateEngine(engineDTO);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            this.engineService.DeleteEngine(Guid.Parse(id));
        }
    }
}