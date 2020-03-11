using Domain.Models;
using Repository.Interfaces.Repositories;


namespace Repository.Repositories
{
    public class EngineRepository : Repository<Engine>, IEngineRepository
    {
        public EngineRepository(AplicationContext context) : base(context) { }

        public AplicationContext AplicationContext
        {
            get { return context as AplicationContext; }
        }
    }
}