using System;
using System.Collections.Generic;
using Domain.Models;
using Service.DTO;

namespace Service.Interfaces
{
    public interface ICarService
    {
        IEnumerable<CarDTO> GetCars();
        CarDTO GetCar(Guid Id);
        void InsertCar(CarDTO carDTO);
        void UpdateCar(CarDTO carDTO);
        void DeleteCar(Guid Id);

        Car GetCar22(Guid Id);
    }
}
