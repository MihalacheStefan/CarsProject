using System;
using Microsoft.EntityFrameworkCore;


namespace Repository.Tests.Common
{
    public class AplicationContextFactory
    {
        private bool useSqlite = false;

        public AplicationContext Create()
        {
            var builder = new DbContextOptionsBuilder<AplicationContext>();
                
            if (this.useSqlite)
                builder.UseSqlite("DataSource=:memory:", x => { });
            else
                // In Memory does not suport relational database
                builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            var context = new AplicationContext(builder.Options);
            if (this.useSqlite)
                // Sqlite needs to open connection to DB
                context.Database.OpenConnection();

            context.Database.EnsureCreated();

            return context;
        }

        public void UseSqlite()
        {
            this.useSqlite = true;
        }

        public void Destroy(AplicationContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
