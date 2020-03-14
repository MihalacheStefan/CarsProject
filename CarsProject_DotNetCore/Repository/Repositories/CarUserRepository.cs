using Domain.Models;
using Repository.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
