using System;
using Service.DTO;


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
