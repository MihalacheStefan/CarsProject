using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Models;
using Repository.Repositories;
using Repository.Tests.Common;

namespace Repository.Tests.Repositories
{
    [TestClass]
    public class UserRepositoryTests : TestBase
    {
        [TestMethod]
        public void ShouldReturnUserFromGetMethod()
        {
            //Arrange
            var context = GetSqliteAplicationContext();
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Name = "Elise",
                CarsUsers = null
            };
            context.Users.Add(user);
            var userRepository = new UserRepository(context);

            //Act
            var userFromDB = userRepository.Get(user.UserId);

            //Assert
            Assert.IsNotNull(userFromDB);
            Assert.IsInstanceOfType(userFromDB, user.GetType());

        }

        [TestMethod]
        public void GetAllIsInstanceOfIEnumerable()
        {
            //Arrange
            var context = GetInMemoryAplicationContext();
            IEnumerable<User> list = new List<User>();
            var objIEnumerable = list.GetType();
            var userRepository = new UserRepository(context);

            //Act
            var users = userRepository.GetAll();

            //Assert
            Assert.IsNotNull(users);
            Assert.IsInstanceOfType(users, objIEnumerable.GetInterface("IEnumerable"));
        }
        
        [TestMethod]
        public void ShouldAddNewUserInMemory()
        {
            //Arrange
            var context = GetInMemoryAplicationContext();
            var userRepository = new UserRepository(context);

            //Act
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Name = "Elise",
                CarsUsers = null
            };
            userRepository.Add(user);

            //Assert
            Assert.AreEqual(1, context.Users.Local.Count());
        }

        [TestMethod]
        public void ShouldUpdateUser()
        {
            //Arrange
            var context = GetSqliteAplicationContext();
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Name = "Elise",
                CarsUsers = null
            };
            context.Users.Add(user);
            var userRepository = new UserRepository(context);

            //Act
            user.Name = "Bob";
            userRepository.Update(user);
            var userFromDB = userRepository.Get(user.UserId);

            //Assert
            Assert.IsNotNull(userFromDB);
            Assert.AreEqual(userFromDB.Name, "Bob");
        }

        [TestMethod]
        public void ShouldRemoveUserInMemory()
        {
            //Arrange
            var context = GetInMemoryAplicationContext();
            var user = new User
            {
                UserId = Guid.Parse("00000001-0000-0000-0000-000000000000"),
                Name = "John",
                CarsUsers = new List<CarUser>()
            };
            context.Users.Add(user);
            var userRepository = new UserRepository(context);
           
            //Act
            userRepository.Remove(user);

            //Assert
            Assert.AreEqual(0, context.Users.Local.Count);
        }

        //[TestMethod]
        //public void ShouldReturnUserFromGetByName()
        //{
        //    //Arrange
        //    var context = GetSqliteAplicationContext();
        //    var user = new User
        //    {
        //        UserId = Guid.NewGuid(),
        //        Name = "Elise",
        //        CarsUsers = null
        //    };
        //    context.Users.Add(user);
        //    var userRepository = new UserRepository(context);

        //    //Act
        //    //var userFromDB = userRepository.Get(user.UserId);
        //    var userFromDB = userRepository.GetByName("Elise");

        //    //Assert
        //    Assert.IsNotNull(userFromDB);
        //    Assert.IsInstanceOfType(userFromDB, user.GetType());
        //}
    }
}
