using Domain.Models;
using Repository.Interfaces.Repositories;


namespace Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AplicationContext context) : base(context) { }

        public AplicationContext AplicationContext
        {
            get { return context as AplicationContext; }
        }
    }
}