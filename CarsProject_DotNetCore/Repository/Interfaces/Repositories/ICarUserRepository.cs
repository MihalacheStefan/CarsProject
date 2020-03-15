using System;
using Domain.Models;

namespace Repository.Interfaces.Repositories
{
    public interface ICarUserRepository : IRepository<CarUser>
    {
        CarUser GetByCarIdAndUserId(Guid CarId, Guid UserId);
    }
}
