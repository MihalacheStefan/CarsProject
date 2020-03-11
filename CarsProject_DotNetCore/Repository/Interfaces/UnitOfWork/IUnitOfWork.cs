using System;
using Repository.Interfaces.Repositories;


namespace Repository.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRepository Cars { get; }
        IChassisRepository Chassiss { get; }
        IEngineRepository Engines { get; }
        IUserRepository Users { get; }
        int Complete();
    }
}
