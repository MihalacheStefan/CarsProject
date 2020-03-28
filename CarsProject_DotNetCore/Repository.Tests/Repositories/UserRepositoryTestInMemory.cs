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
    public class UserRepositoryTestInMemory : TestBase
    {
        
        [TestMethod]
        public void GetAllIsInstanceOfIEnumerable()
        {
            //Arrange
            IEnumerable<User> list = new List<User>();
            var objIEnumerable = list.GetType();
            var userRepository = new UserRepository(_context);

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
            var userRepository = new UserRepository(_context);

            //Act
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Name = "Elise",
                CarsUsers = null //new List<CarUser>()
            };
            userRepository.Add(user);

            //Assert
            Assert.AreEqual(1, _context.Users.Local.Count());
        }

        [TestMethod]
        public void ShouldDeleteUserInMemory()
        {
            //Arrange
            var user = new User
            {
                UserId = Guid.Parse("00000001-0000-0000-0000-000000000000"),
                Name = "John",
                CarsUsers = new List<CarUser>()
            };
            _context.Users.Add(user);
            var userRepository = new UserRepository(_context);
           
            //Act
            userRepository.Remove(user);

            //Assert
            Assert.AreEqual(0, _context.Users.Local.Count);
        }

    }
}
