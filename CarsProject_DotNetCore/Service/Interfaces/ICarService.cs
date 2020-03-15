using System;
using System.Collections.Generic;
using Service.DTO;

namespace Service.Interfaces
{
    public interface ICarService
    {
        IEnumerable<CarDTO> GetCars();
        CarDTO GetCar(Guid Id);
        CarDTO GetCar(string brand);
        void InsertCar(CarDTO carDTO);
        void UpdateCar(CarDTO carDTO);
        void DeleteCar(Guid Id);
        void DeleteCar(string brand);
    }
}
