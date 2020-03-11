using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;

namespace CarsProject_DotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICarService carService;
        private readonly IChassisService chassisService;
       
        public ValuesController(ICarService carService, IChassisService chassisService)
        {
            this.carService = carService;
            this.chassisService = chassisService;

        }

        // GET api/values
        [HttpGet]
        public void Get()
        {
            IEnumerable<CarDTO> cars = this.carService.GetCars() as IEnumerable<CarDTO>;         
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ChassisDTO> Get(string id)
        {
            var car = this.chassisService.GetChassis(Guid.Parse(id));
            return car;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] CarDTO value)
        {
            this.carService.InsertCar(value);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
