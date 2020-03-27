using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Repository.Tests.Common
{
    public class TestBase : IDisposable
    {
        protected readonly AplicationContext _context;

        public TestBase()
        {
            _context = AplicationContextFactory.Create();
        }

        public void Dispose()
        {
            AplicationContextFactory.Destroy(_context);
        }
    }
}
