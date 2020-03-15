using System;
using System.Collections.Generic;
using AutoMapper;
using Domain.Models;
using Repository.Interfaces.UnitOfWork;
using Service.DTO;
using Service.Interfaces;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;


        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            IEnumerable<User> users = this.unitOfWork.Users.GetAll();
            return this.mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public UserDTO GetUser(Guid Id)
        {
            User user = this.unitOfWork.Users.Get(Id);
            return this.mapper.Map<UserDTO>(user);
        }

        public void InsertUser(UserDTO userDTO)
        {
            User user = this.mapper.Map<User>(userDTO);
            user.UserId = Guid.NewGuid();
            user.CarsUsers = this.GetCarsUsers(user, this.GetCarsByBrand(userDTO.Brands));
            this.unitOfWork.Users.Add(user);
            this.unitOfWork.Complete();
        }

        public void UpdateUser(UserDTO userDTO)
        {
            User user = unitOfWork.Users.GetByName(userDTO.Name);
            if (user != null)
            {
                var updatedCarsUsers = this.GetCarsUsers(user, this.GetCarsByBrand(userDTO.Brands));

                foreach (var carUser in user.CarsUsers)
                    if (!updatedCarsUsers.Contains(carUser))
                        this.unitOfWork.CarsUsers.Remove(carUser);

                user.CarsUsers = updatedCarsUsers;
                this.unitOfWork.Users.Update(user);
                this.unitOfWork.Complete();
            }
            else
                this.InsertUser(userDTO);
        }

        public void DeleteUser(Guid Id)
        {
            User user = this.unitOfWork.Users.Get(Id);
            this.unitOfWork.Users.Remove(user);
            this.unitOfWork.Complete();
        }

        private ICollection<Car> GetCarsByBrand(ICollection<string> Brands)
        {
            ICollection<Car> cars = new List<Car>();
            foreach (var brand in Brands)
            {
                var car = this.unitOfWork.Cars.GetByBrand(brand);
                if (car != null)
                    cars.Add(car);
                else
                    throw new Exception("Bad Request parameters");
            }
            return cars;
        }

        private ICollection<CarUser> GetCarsUsers(User user, ICollection<Car> cars)
        {
            ICollection<CarUser> carsUsers = new List<CarUser>();
            foreach (var car in cars)
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
