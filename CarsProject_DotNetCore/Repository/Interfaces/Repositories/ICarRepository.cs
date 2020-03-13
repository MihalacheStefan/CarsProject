using Domain.Models;


namespace Repository.Interfaces.Repositories
{
    public interface ICarRepository: IRepository<Car>
    {
        Car GetByBrand(string brand);
    }
}
