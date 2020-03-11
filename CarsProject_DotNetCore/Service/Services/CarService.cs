using System;
using System.Collections.Generic;
using AutoMapper;
using Domain.Models;
using Repository.Interfaces.UnitOfWork;
using Service.DTO;
using Service.Interfaces;

namespace Service.Services
{
    public class CarService : ICarService
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CarService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<CarDTO> GetCars()
        {
            IEnumerable<Car> cars = this.unitOfWork.Cars.GetAll();
            return null;
            //IEnumerable<CarDTO> carsDTO = new CarDTO[] { };
            //foreach (var car in cars)
            //{
            //    CarDTO carDTO = new CarDTO();
            //    carDTO = _mapper.Map<CarDTO>(car);
            //    carDTO.Chassis = _mapper.Map<ChassisDTO>(car.Chassis);
            //    carDTO.Engine = _mapper.Map<EngineDTO>(car.Engine);
            //    carsDTO.ToList().Add(carDTO);
            //}
            //return carsDTO.ToList();
        }

        public CarDTO GetCar(Guid Id)
        {
            var car = this.unitOfWork.Cars.Get(Id);
            var carDTO =  mapper.Map<CarDTO>(car);
            carDTO.Chassis = mapper.Map<ChassisDTO>(car.Chassis);
            carDTO.Engine = mapper.Map<EngineDTO>(car.Engine);
            return carDTO;
        }

        public Car GetCar22(Guid Id)
        {
            var x = this.unitOfWork.Cars.Get(Id);
            return x;
        }

        public void InsertCar(CarDTO carDTO)
        {
            Car car = this.mapper.Map<Car>(carDTO);
            car.CarId = Guid.NewGuid();
            this.unitOfWork.Cars.Add(car);
            this.unitOfWork.Complete();
        }

        public void UpdateCar(CarDTO carDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteCar(Guid Id)
        {
            Car car = this.unitOfWork.Cars.Get(Id);
            this.unitOfWork.Cars.Remove(car);
            this.unitOfWork.Complete();
        }

    }
}