﻿using System;


namespace Repository.Tests.Common
{
    public class TestBase : IDisposable
    {
        protected AplicationContext context;
        private readonly AplicationContextFactory contextFactory;

        public TestBase()
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
