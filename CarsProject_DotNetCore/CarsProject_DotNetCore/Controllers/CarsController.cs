using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;

namespace CarsProject_DotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        private readonly ICarService carService;
        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarDTO>> GetAll()
        {
            return this.carService.GetCars().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<CarDTO> Get(string id)
        {
            return this.carService.GetCar(Guid.Parse(id));
        }

        [HttpPost]
        public void Post([FromBody] CarDTO carDTO)
        {
            this.carService.InsertCar(carDTO);
        }

        [HttpPut]
        public void Put([FromBody] CarDTO carDTO)
        {
            this.carService.UpdateCar(carDTO);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            this.carService.DeleteCar(Guid.Parse(id));
        }
    }
}