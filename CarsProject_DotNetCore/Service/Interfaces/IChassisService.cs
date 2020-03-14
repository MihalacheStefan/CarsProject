using System;
using System.Collections.Generic;
using Service.DTO;


namespace Service.Interfaces
{
    public interface IChassisService
    {
        IEnumerable<ChassisDTO> GetChassiss();
        ChassisDTO GetChassis(Guid Id);
        void InsertChassis(ChassisDTO chassisDTO);
        void UpdateChassis(ChassisDTO chassisDTO);
        void DeleteChassis(Guid Id);
    }
}
