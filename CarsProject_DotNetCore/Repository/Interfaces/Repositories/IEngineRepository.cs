using Domain.Models;


namespace Repository.Interfaces.Repositories
{
    public interface IEngineRepository : IRepository<Engine>
    {
        Engine GetByCylindersNumber(int cylindersNumber);
    }
}
