using System;
using System.Linq;
using Domain.Models;
using Repository.Interfaces.Repositories;


namespace Repository.Repositories
{
    public class CarUserRepository : Repository<CarUser>, ICarUserRepository
    {
        public CarUserRepository(AplicationContext context) : base(context)
        {
        }

        public AplicationContext AplicationContext
        {
            get { return context as AplicationContext; }
        }

        public CarUser GetByCarIdAndUserId(Guid CarId, Guid UserId)
        {
            return this.context.Set<CarUser>().Where(x => x.CarId == CarId && x.UserId == UserId).SingleOrDefault();
        }
    }
}
