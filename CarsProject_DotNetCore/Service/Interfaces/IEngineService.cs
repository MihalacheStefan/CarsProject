using System;
using Domain.Models;
using Service.DTO;


namespace Service.Interfaces
{
    public interface IEngineService
    {
        EngineDTO GetEngine(Guid Id);
        void InsertEngine(EngineDTO engineDTO);
        void UpdateEngine(EngineDTO engineDTO);
        void DeleteEngine(Guid Id);
    }
}
