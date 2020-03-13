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
            //car.CarId = Guid.NewGuid();
            this.unitOfWork.Cars.Add(car);
            this.unitOfWork.Complete();
        }

        public void UpdateCar(CarDTO carDTO)
        {
            Car updatedCar = this.mapper.Map<Car>(carDTO);
            Car car = this.unitOfWork.Cars.GetByBrand(updatedCar.Brand);
            if (car != null)
            {
                car.Chassis.Description = updatedCar.Chassis.Description;
                car.Chassis.CodeNumber = updatedCar.Chassis.CodeNumber;
                car.Chassis.Cars = updatedCar.Chassis.Cars;
                car.Engine.Description = updatedCar.Engine.Description;
                car.Engine.CylindersNumber = updatedCar.Engine.CylindersNumber;
                car.Engine.Cars = updatedCar.Engine.Cars;
                this.unitOfWork.Cars.Update(car);
                this.unitOfWork.Complete();
            }
            else
            {
                this.InsertCar(carDTO);
            }
        }

        public void DeleteCar(Guid Id)
        {
            Car car = this.unitOfWork.Cars.Get(Id);
            this.unitOfWork.Cars.Remove(car);
            this.unitOfWork.Complete();
        }

    }
}