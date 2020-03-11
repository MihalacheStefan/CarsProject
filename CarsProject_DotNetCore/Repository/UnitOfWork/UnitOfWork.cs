using Repository.Repositories;
using Repository.Interfaces.UnitOfWork;
using Repository.Interfaces.Repositories;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AplicationContext context;

        public UnitOfWork(AplicationContext context)
        {
            this.context = context;
            Cars = new CarRepository(this.context);
            Chassiss = new ChassisRepository(this.context);
            Engines = new EngineRepository(this.context);
            Users = new UserRepository(this.context);
        }
        public ICarRepository Cars { get; private set; }
        public IChassisRepository Chassiss { get; private set; }
        public IEngineRepository Engines { get; private set; }
        public IUserRepository Users { get; private set; }

        public int Complete()
        {
            return this.context.SaveChanges();
        }
        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}