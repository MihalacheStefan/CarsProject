using System;


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
