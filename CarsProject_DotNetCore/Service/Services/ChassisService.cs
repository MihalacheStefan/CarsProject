using System;
using AutoMapper;
using Domain.Models;
using Repository.Interfaces.UnitOfWork;
using Service.DTO;
using Service.Interfaces;


namespace Service.Services
{
    public class ChassisService : IChassisService
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ChassisService( IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ChassisDTO GetChassis(Guid Id)
        {
            Chassis chassis = this.unitOfWork.Chassiss.Get(Id);
            return this.mapper.Map<ChassisDTO>(chassis);
        }

        public void InsertChassis(ChassisDTO chassisDTO)
        {
            Chassis chassis = this.mapper.Map<Chassis>(chassisDTO);
            chassis.ChassisId = Guid.NewGuid();
            this.unitOfWork.Chassiss.Add(chassis);
            this.unitOfWork.Complete();
        }

        public void UpdateChassis(ChassisDTO chassisDTO)
        {
            Chassis updatedChassis = this.mapper.Map<Chassis>(chassisDTO);
            Chassis chassis = unitOfWork.Chassiss.GetByCodeNumber(updatedChassis.CodeNumber);
            if (chassis != null)
            {
                chassis.Description = updatedChassis.Description;
                chassis.Cars = updatedChassis.Cars;
                this.unitOfWork.Chassiss.Update(chassis);
                this.unitOfWork.Complete();
            }
            else
            {
                this.InsertChassis(chassisDTO);
            }
        }

        public void DeleteChassis(Guid Id)
        {
            Chassis chassis = this.unitOfWork.Chassiss.Get(Id);
            this.unitOfWork.Chassiss.Remove(chassis);
            this.unitOfWork.Complete();
        }
    }
}
