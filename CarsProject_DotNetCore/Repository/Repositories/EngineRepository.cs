using Domain.Models;
using Repository.Interfaces.Repositories;
using System.Linq;

namespace Repository.Repositories
{
    public class EngineRepository : Repository<Engine>, IEngineRepository
    {
        public EngineRepository(AplicationContext context) : base(context) { }

        public AplicationContext AplicationContext
        {
            get { return context as AplicationContext; }
        }

        public Engine GetByCylindersNumber(int cylindersNumber)
        {
            return this.context.Set<Engine>().Where(x => x.CylindersNumber == cylindersNumber).FirstOrDefault();
        }
    }
}