using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Repository.UnitOfWork;
using Repository.Interfaces.UnitOfWork;

namespace Repository.Tests.UnitOfWork
{
    [TestClass]
    public class UnitOfWorkTests
    {
        private Mock<AplicationContext> AplicationContextMock;

        [TestInitialize]
        public void Initialize()
        {
            AplicationContextMock = new Mock<AplicationContext>(new DbContextOptions<AplicationContext>());
        }

        [TestMethod]
        public void UnitOfWork_Is_Instance_Of_IUnitOfWork()
        {
            //var IUnitOfWork = new UnitOfWork(AplicationContextMock.Object);

            //Type obj = unitOfWork.GetType();

            //Assert.IsInstanceOfType(unitOfWork, obj.GetInterface("IUnitOfWork"));
        }

    }
}
