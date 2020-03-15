using System;
using System.Collections.Generic;
using Service.DTO;


namespace Service.Interfaces
{
    public interface IEngineService
    {
        IEnumerable<EngineDTO> GetEngines();
        EngineDTO GetEngine(Guid Id);
        EngineDTO GetEngine(int cylindersNumber);
        void InsertEngine(EngineDTO engineDTO);
        void UpdateEngine(EngineDTO engineDTO);
        void DeleteEngine(Guid Id);
        void DeleteEngine(int cylindersNumber);

    }
}
