using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Models;
using Service.DTO;


namespace Infrastructure.Tests.Mappings
{
    [TestClass]
    public class MappingTests : MappingTestsFixture
    {
        [TestMethod]
        public void ShouldHaveValidConfiguration()
        {
            ConfigurationProvider.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void ShouldMapCarToCarDTO()
        {
            //Arrange
            var car = new Car();
            var carDTO = new CarDTO();
            var carDTOType = carDTO.GetType();

            //Act
            var result = Mapper.Map<CarDTO>(car);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, carDTOType);
        }

        [TestMethod]
        public void ShouldMapCarDTOToCar()
        {
            //Arrange
            var car = new Car();
            var carDTO = new CarDTO();
            var carType = car.GetType();

            //Act
            var result = Mapper.Map<Car>(carDTO);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, carType);
        }

        [TestMethod]
        public void ShouldMapEngineToEngineDTO()
        {
            //Arrange
            var engine = new Engine();
            var engineDTO = new EngineDTO();
            var engineDTOType = engineDTO.GetType();

            //Act
            var result = Mapper.Map<EngineDTO>(engine);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, engineDTOType);
        }

        [TestMethod]
        public void ShouldMapEngineDTOToEngine()
        {
            //Arrange
            var engine = new Engine();
            var engineDTO = new EngineDTO();
            var engineType = engine.GetType();

            //Act
            var result = Mapper.Map<Engine>(engineDTO);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, engineType);
        }

        [TestMethod]
        public void ShouldMapChassisToChassisDTO()
        {
            //Arrange
            var chassis = new Chassis();
            var chassisDTO = new ChassisDTO();
            var chassisDTOType = chassisDTO.GetType();

            //Act
            var result = Mapper.Map<ChassisDTO>(chassis);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, chassisDTOType);
        }

        [TestMethod]
        public void ShouldMapChassisDTOToChassis()
        {
            //Arrange
            var chassis = new Chassis();
            var chassisDTO = new ChassisDTO();
            var chassisType = chassis.GetType();

            //Act
            var result = Mapper.Map<Chassis>(chassisDTO);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, chassisType);
        }

        [TestMethod]
        public void ShouldMapUserToUserDTO()
        {
            //Arrange
            var user = new User();
            var userDTO = new UserDTO();
            var userDTOType = userDTO.GetType();

            //Act
            var result = Mapper.Map<UserDTO>(user);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, userDTOType);
        }

        [TestMethod]
        public void ShouldMapUserDTOToUser()
        {
            //Arrange
            var user = new User();
            var userDTO = new UserDTO();
            var userType = user.GetType();

            //Act
            var result = Mapper.Map<User>(userDTO);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, userType);
        }

    }
}
