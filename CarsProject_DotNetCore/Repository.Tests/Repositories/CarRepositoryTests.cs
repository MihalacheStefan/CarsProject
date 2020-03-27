using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.Models;
using Repository.Repositories;


namespace Repository.Tests.Repositories
{
    [TestClass]
    public class CarRepositoryTests 
    {
        private Mock<DbSet<Car>> dbSetMock;
        private Mock<AplicationContext> AplicationContextMock;

        [TestInitialize]
        public void Initialize()
        {
            dbSetMock = new Mock<DbSet<Car>>();
            AplicationContextMock = new Mock<AplicationContext>(new DbContextOptions<AplicationContext>());
        }

        [TestMethod]
        public void CarRepository_Is_Instance_Of_ICarRepository()
        {
            var carRepository = new CarRepository(AplicationContextMock.Object);

            Type obj = carRepository.GetType();

            Assert.IsInstanceOfType(carRepository, obj.GetInterface("ICarRepository"));
        }

        [TestMethod]
        public void GetById_Returns_Car()
        {
            var car = new Car();
            dbSetMock.Setup(s => s.Find(It.IsAny<Guid>())).Returns(car);
            AplicationContextMock.Setup(s => s.Set<Car>()).Returns(dbSetMock.Object);

            var carRepository = new CarRepository(AplicationContextMock.Object);
            var result = carRepository.Get(Guid.NewGuid());

            Assert.IsInstanceOfType(result, car.GetType());
        }

        [TestMethod]
        public void GetById_Returns_NotNull()
        {
            dbSetMock.Setup(s => s.Find(It.IsAny<Guid>())).Returns(new Car());
            AplicationContextMock.Setup(s => s.Set<Car>()).Returns(dbSetMock.Object);

            var carRepository = new CarRepository(this.AplicationContextMock.Object);
            var result = carRepository.Get(Guid.NewGuid());

            Assert.IsNotNull(result);
        }

        [TestCleanup]
        public void CarRepositoryTearDown()
        {
            dbSetMock.Reset();
            AplicationContextMock.Reset();
        }

    }
}
