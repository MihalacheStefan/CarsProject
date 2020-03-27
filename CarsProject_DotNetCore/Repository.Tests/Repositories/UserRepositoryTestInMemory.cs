using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Models;
using System.Text;
using Repository.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Repository.Tests.Common;

namespace Repository.Tests.Repositories
{
    [TestClass]
    public class UserRepositoryTestInMemory : TestBase
    {
        //private AplicationContext InitAndGetDbContext()
        //{
        //    var context = GetDbContext();

        //    context.Users.Add(new User
        //    {
        //        UserId = Guid.Parse("00000001-0000-0000-0000-000000000000"),
        //        Name = "John",
        //        CarsUsers = new List<CarUser>()
        //    });

        //    context.Users.Add(new User
        //    {
        //        UserId = Guid.Parse("00000002-0000-0000-0000-000000000000"),
        //        Name = "Bob",
        //        CarsUsers = new List<CarUser>()
        //    });

        //    context.SaveChanges();
        //    return context;
        //}

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

        //[TestMethod]
        //public void ShouldDeleteUserInMemory()
        //{
        //    //Arrange
        //    _context.Users.Add(new User
        //    {
        //        UserId = Guid.Parse("00000001-0000-0000-0000-000000000000"),
        //        Name = "John",
        //        CarsUsers = new List<CarUser>()
        //    });
        //    var userRepository = new UserRepository(_context);

        //    //Act
        //    var user = userRepository.GetByName("John");

        //    //Assert
        //    Assert.IsNotNull(user);
        //}
    
    }
}
