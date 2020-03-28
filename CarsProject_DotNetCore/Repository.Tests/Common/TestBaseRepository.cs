using System;


namespace Repository.Tests.Common
{
    public class TestBaseRepository : IDisposable
    {
        protected AplicationContext context;
        private readonly AplicationContextFactory contextFactory;

        public TestBaseRepository()
        {
            contextFactory = new AplicationContextFactory();
        }

        public AplicationContext GetInMemoryAplicationContext()
        {
            this.context = contextFactory.Create();
            return this.context;
        }

        public AplicationContext GetSqliteAplicationContext()
        {
            this.contextFactory.UseSqlite();
            this.context = contextFactory.Create();
            return this.context;
        }

        public void Dispose()
        {
            contextFactory.Destroy(context);
        }
    }
}
