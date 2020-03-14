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
            return this.mapper.Map<IEnumerable<CarDTO>>(cars);
        }

        public CarDTO GetCar(Guid Id)
        {
            var car = this.unitOfWork.Cars.Get(Id);
            return this.mapper.Map<CarDTO>(car);
        }

        public void InsertCar(CarDTO carDTO)
        {
            Car car = this.mapper.Map<Car>(carDTO);
            var chassis = this.unitOfWork.Chassiss.GetByCodeNumber(carDTO.ChassisCodeNumber);
            if (chassis != null)
                car.Chassis = chassis;
            var engine = this.unitOfWork.Engines.GetByCylindersNumber(carDTO.EngineCylindersNumber);
            if (engine != null)
                car.Engine = engine;
            this.unitOfWork.Cars.Add(car);
            this.unitOfWork.Complete();
        }

        public void UpdateCar(CarDTO carDTO)
        {
            Car car = this.unitOfWork.Cars.GetByBrand(carDTO.Brand);
            if (car != null)
            {
                var chassis = this.unitOfWork.Chassiss.GetByCodeNumber(carDTO.ChassisCodeNumber);
                if (chassis != null)
                    car.Chassis = chassis;
                else
                    throw new Exception("Bad request Parameters");

                var engine = this.unitOfWork.Engines.GetByCylindersNumber(carDTO.EngineCylindersNumber);
                if (engine != null)
                    car.Engine = engine;
                else
                    throw new Exception("Bad request Parameters");

                this.unitOfWork.Cars.Update(car);
                this.unitOfWork.Complete();
            }
            else
                this.InsertCar(carDTO);
        }

        public void DeleteCar(Guid Id)
        {
            Car car = this.unitOfWork.Cars.Get(Id);
            this.unitOfWork.Cars.Remove(car);
            this.unitOfWork.Complete();
        }

    }
}