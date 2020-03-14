using System;
using System.Collections.Generic;
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

        public IEnumerable<ChassisDTO> GetChassiss()
        {
            IEnumerable<Chassis> chassiss = this.unitOfWork.Chassiss.GetAll();
            return this.mapper.Map<IEnumerable<ChassisDTO>>(chassiss);
        }

        public ChassisDTO GetChassis(Guid Id)
        {
            Chassis chassis = this.unitOfWork.Chassiss.Get(Id);
            return this.mapper.Map<ChassisDTO>(chassis);
        }

        public void InsertChassis(ChassisDTO chassisDTO)
        {
            Chassis chassis = this.mapper.Map<Chassis>(chassisDTO);
            chassis.Cars = this.GetCarsByBrand(chassisDTO.Brands);
            this.unitOfWork.Chassiss.Add(chassis);
            this.unitOfWork.Complete();
        }

        public void UpdateChassis(ChassisDTO chassisDTO)
        {
            Chassis chassis = unitOfWork.Chassiss.GetByCodeNumber(chassisDTO.CodeNumber);
            if (chassis != null)
            {
                chassis.Description = chassisDTO.Description;
                chassis.Cars = this.GetCarsByBrand(chassisDTO.Brands);
                this.unitOfWork.Chassiss.Update(chassis);
                this.unitOfWork.Complete();
            }
            else
                this.InsertChassis(chassisDTO);
        }

        public void DeleteChassis(Guid Id)
        {
            Chassis chassis = this.unitOfWork.Chassiss.Get(Id);
            this.unitOfWork.Chassiss.Remove(chassis);
            this.unitOfWork.Complete();
        }

        private ICollection<Car> GetCarsByBrand(ICollection<string> Brands)
        {
            ICollection<Car> Cars = new List<Car>();
            foreach (var brand in Brands)
            {
                var car = this.unitOfWork.Cars.GetByBrand(brand);
                if (car != null)
                    Cars.Add(car);
                else
                    throw new Exception("Bad Request parameters");
            }
            return Cars;
        }

    }
}
