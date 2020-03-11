using System;
using Domain.Models;
using Service.DTO;

// Prima oara cele din SYstem
// Dupa ordonare dupa layere

    // System
    // Service
    // Repo
    // ...


namespace Service.Interfaces
{
    public interface IChassisService
    {
        ChassisDTO GetChassis(Guid Id);
        void InsertChassis(ChassisDTO chassisDTO);
        void UpdateChassis(ChassisDTO chassisDTO);
        void DeleteChassis(Guid Id);
    }
}
