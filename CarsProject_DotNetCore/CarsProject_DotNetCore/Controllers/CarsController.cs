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

        [HttpGet("{brand}")]
        public ActionResult<CarDTO> GetByName(string brand)
        {
            return this.carService.GetCar(brand);
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

        [HttpDelete("{brand}")]
        public void Delete(string brand)
        {
            this.carService.DeleteCar(brand);
        }
    }
}