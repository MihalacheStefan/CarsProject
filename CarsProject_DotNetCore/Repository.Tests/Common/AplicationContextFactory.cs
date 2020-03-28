using System;
using Microsoft.EntityFrameworkCore;


namespace Repository.Tests.Common
{
    public class AplicationContextFactory
    {
        public static AplicationContext Create()
        {
            var options = new DbContextOptionsBuilder<AplicationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())     //In Memory does not suport relational database
                .Options;
            
            var context = new AplicationContext(options);

            context.Database.EnsureCreated();

            return context;
        }

        public static void Destroy(AplicationContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
