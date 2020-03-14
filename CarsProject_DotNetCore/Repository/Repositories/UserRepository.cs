using Domain.Models;
using Repository.Interfaces.Repositories;
using System.Linq;

namespace Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AplicationContext context) : base(context) { }

        public AplicationContext AplicationContext
        {
            get { return context as AplicationContext; }
        }

        public User GetByName(string Name)
        {
            return this.context.Set<User>().Where(x => x.Name == Name).SingleOrDefault();
        }
    }
}