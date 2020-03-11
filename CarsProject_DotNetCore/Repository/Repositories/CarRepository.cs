using Domain.Models;
using Repository.Interfaces.Repositories;

namespace Repository.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(AplicationContext context) : base(context) { } 

        public AplicationContext AplicationContext
        {
            get { return context as AplicationContext; }
        }
    }
}