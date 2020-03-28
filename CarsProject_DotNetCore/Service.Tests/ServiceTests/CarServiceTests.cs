using AutoMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repository;
using Repository.Interfaces.UnitOfWork;
using Repository.UnitOfWork;
using Service.DTO;
using Service.Services;
using System;
using System.Collections.Generic;

namespace Service.Tests.ServiceTests
{
    [TestClass]
    public class CarServiceTests
    {
        private Mock<AplicationContext> AplicationContextMock;
        private Mock<IUnitOfWork> UnitOfWorkMock;
        private Mock<IMapper> MapperMock;

        [TestInitialize]
        public void Initialize()
        {
            AplicationContextMock = new Mock<AplicationContext>(new DbContextOptions<AplicationContext>());
            UnitOfWorkMock = new Mock<IUnitOfWork>();
            MapperMock = new Mock<IMapper>();
        }

        [TestMethod]
        public void UpdateCarShouldThrowExceptionOnNullBrandOfCarDTO()
        {
            //Arrange
            var carService = new CarService(UnitOfWorkMock.Object, MapperMock.Object);
            Exception exception = null;

            //Act
            try
            {
                carService.UpdateCar(new CarDTO());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            //Assert
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void UpdateCarShouldThrowExceptionOnNullChassisOfCarDTO()
        {
            //Arrange
            UnitOfWorkMock.Setup(u => u.Cars.GetByBrand(It.IsAny<string>())).Returns(new Car());
            UnitOfWorkMock.Setup(u => u.Chassiss.GetByCodeNumber(It.IsAny<string>())).Returns(null as Chassis);
            var carService = new CarService(UnitOfWorkMock.Object, MapperMock.Object);
            var carDTO = new CarDTO{
                Brand = "AAA"
            };
            Exception exception = null;

            //Act
            try
            {
                carService.UpdateCar(carDTO);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            //Assert
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void UpdateCarShouldThrowExceptionOnNullEngineOfCarDTO()
        {
            //Arrange
            UnitOfWorkMock.Setup(u => u.Cars.GetByBrand(It.IsAny<string>())).Returns(new Car());
            UnitOfWorkMock.Setup(u => u.Chassiss.GetByCodeNumber(It.IsAny<string>())).Returns(new Chassis());
            UnitOfWorkMock.Setup(u => u.Engines.GetByCylindersNumber(It.IsAny<int>())).Returns(null as Engine);
            var carService = new CarService(UnitOfWorkMock.Object, MapperMock.Object);
            var carDTO = new CarDTO
            {
                Brand = "AAA"
            };
            Exception exception = null;

            //Act
            try
            {
                carService.UpdateCar(carDTO);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            //Assert
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void UpdateCarShouldThrowExceptionOnWrongUserNameOfCarDTO()
        {
            //Arrange
            UnitOfWorkMock.Setup(u => u.Cars.GetByBrand(It.IsAny<string>())).Returns(new Car());
            UnitOfWorkMock.Setup(u => u.Chassiss.GetByCodeNumber(It.IsAny<string>())).Returns(new Chassis());
            UnitOfWorkMock.Setup(u => u.Engines.GetByCylindersNumber(It.IsAny<int>())).Returns(new Engine());
            UnitOfWorkMock.Setup(u => u.Users.GetByName(It.IsAny<string>())).Returns(null as User);
            var carService = new CarService(UnitOfWorkMock.Object, MapperMock.Object);
            var carDTO = new CarDTO
            {
                Brand = "AAA",
                UsersName = new List<string> { "John" }
            };
            Exception exception = null;

            //Act
            try
            {
                carService.UpdateCar(carDTO);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            //Assert
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void UpdateCarShouldUpdateCarDTO()
        {
            //Arrange
            UnitOfWorkMock.Setup(u => u.Cars.GetByBrand(It.IsAny<string>())).Returns(new Car { CarsUsers = new List<CarUser>()});
            UnitOfWorkMock.Setup(u => u.Chassiss.GetByCodeNumber(It.IsAny<string>())).Returns(new Chassis());
            UnitOfWorkMock.Setup(u => u.Engines.GetByCylindersNumber(It.IsAny<int>())).Returns(new Engine());
            UnitOfWorkMock.Setup(u => u.Users.GetByName(It.IsAny<string>())).Returns(new User());
            UnitOfWorkMock.Setup(u => u.CarsUsers.GetByCarIdAndUserId(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(new CarUser());
            var carService = new CarService(UnitOfWorkMock.Object, MapperMock.Object);
            var carDTO = new CarDTO
            {
                Brand = "AAA",
                UsersName = new List<string> { "John" }
            };
            Exception exception = null;

            //Act
            try
            {
                carService.UpdateCar(carDTO);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            //Assert
            Assert.IsNull(exception);
        }


        [TestCleanup]
        public void CarServiceTearDown()
        {
            AplicationContextMock.Reset();
            UnitOfWorkMock.Reset();
            MapperMock.Reset();
        }
    }
}
