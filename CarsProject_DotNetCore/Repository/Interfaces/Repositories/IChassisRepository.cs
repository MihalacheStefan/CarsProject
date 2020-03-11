using Domain.Models;


namespace Repository.Interfaces.Repositories
{
    public interface IChassisRepository : IRepository<Chassis>
    {
        Chassis GetByCodeNumber(string codeNumber);
    }
}
