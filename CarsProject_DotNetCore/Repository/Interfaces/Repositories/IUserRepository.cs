using Domain.Models;


namespace Repository.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByName(string Name);
    }
}
