using System.Linq;
using Domain.Models;
using Repository.Interfaces.Repositories;

namespace Repository.Repositories
{
    public class ChassisRepository : Repository<Chassis>, IChassisRepository
    {
        public ChassisRepository(AplicationContext context) : base(context) { }

        public AplicationContext AplicationContext
        {
            get { return context as AplicationContext; }
        }

        public Chassis GetByCodeNumber(string codeNumber)
        {
            return this.context.Set<Chassis>().Where(x => x.CodeNumber == codeNumber).SingleOrDefault();
        }
    }
}