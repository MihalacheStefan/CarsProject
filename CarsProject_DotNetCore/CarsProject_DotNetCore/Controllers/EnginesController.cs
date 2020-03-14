using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;

namespace CarsProject_DotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnginesController : Controller
    {
        private readonly IEngineService engineService;

        public EnginesController(IEngineService engineService)
        {
            this.engineService = engineService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EngineDTO>> GetAll()
        {
            return this.engineService.GetEngines().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<EngineDTO> Get(string id)
        {
            return this.engineService.GetEngine(Guid.Parse(id));
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