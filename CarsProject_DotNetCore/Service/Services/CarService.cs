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

        public CarDTO GetCar(string brand)
        {
            var car = this.unitOfWork.Cars.GetByBrand(brand);
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
            car.CarsUsers = this.GetCarsUsers(car, this.GetUsersByName(carDTO.UsersName));
            this.unitOfWork.Cars.Add(car);
            this.unitOfWork.Complete();
        }

        public void UpdateCar(CarDTO carDTO)
        {
            if (carDTO.Brand == null)
                throw new Exception("Bad request Parameters");
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

                var updatedCarsUsers = this.GetCarsUsers(car, this.GetUsersByName(carDTO.UsersName));
                foreach (var carUser in car.CarsUsers)
                    if (!updatedCarsUsers.Contains(carUser))
                        this.unitOfWork.CarsUsers.Remove(carUser);
                car.CarsUsers = updatedCarsUsers;

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

        public void DeleteCar(string brand)
        {
            Car car = this.unitOfWork.Cars.GetByBrand(brand);
            this.unitOfWork.Cars.Remove(car);
            this.unitOfWork.Complete();
        }

        private ICollection<User> GetUsersByName(ICollection<string> names)
        {
            ICollection<User> users = new List<User>();
            foreach (var name in names)
            {
                var user = this.unitOfWork.Users.GetByName(name);
                if (user != null)
                    users.Add(user);
                else
                    throw new Exception("Bad Request parameters - No such User");
            }
            return users;
        }

        private ICollection<CarUser> GetCarsUsers(Car car, ICollection<User> users)
        {
            ICollection<CarUser> carsUsers = new List<CarUser>();
            foreach (var user in users)
            {
                var carUserFromDb = this.unitOfWork.CarsUsers.GetByCarIdAndUserId(car.CarId, user.UserId);
                if (carUserFromDb != null)
                    carsUsers.Add(carUserFromDb);
                else
                {
                    var carUser = new CarUser
                    {
                        Car = car,
                        User = user
                    };
                    carsUsers.Add(carUser);
                }
            }
            return carsUsers;
        }

    }
}