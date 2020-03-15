using System;
using System.Collections.Generic;
using AutoMapper;
using Domain.Models;
using Repository.Interfaces.UnitOfWork;
using Service.DTO;
using Service.Interfaces;


namespace Service.Services
{
   public class EngineService : IEngineService
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;


        public EngineService( IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<EngineDTO> GetEngines()
        {
            IEnumerable<Engine> engines = this.unitOfWork.Engines.GetAll();
            return this.mapper.Map<IEnumerable<EngineDTO>>(engines);
        }

        public EngineDTO GetEngine(Guid Id)
        {
            Engine engine = this.unitOfWork.Engines.Get(Id);
            return this.mapper.Map<EngineDTO>(engine);
        }

        public EngineDTO GetEngine(int cylindersNumber)
        {
            Engine engine = this.unitOfWork.Engines.GetByCylindersNumber(cylindersNumber);
            return this.mapper.Map<EngineDTO>(engine);
        }

        public void InsertEngine(EngineDTO engineDTO)
        {
            Engine engine = this.mapper.Map<Engine>(engineDTO);
            engine.Cars = this.GetCarsByBrand(engineDTO.Brands);
            this.unitOfWork.Engines.Add(engine);
            this.unitOfWork.Complete();
        }

        public void UpdateEngine(EngineDTO engineDTO)
        {
            Engine engine = unitOfWork.Engines.GetByCylindersNumber(engineDTO.CylindersNumber);
            if (engine != null)
            {
                engine.Description = engineDTO.Description;
                engine.Cars = this.GetCarsByBrand(engineDTO.Brands);
                this.unitOfWork.Engines.Update(engine);
                this.unitOfWork.Complete();
            }
            else
                this.InsertEngine(engineDTO);
        }

        public void DeleteEngine(Guid Id)
        {
            Engine engine = this.unitOfWork.Engines.Get(Id);
            this.unitOfWork.Engines.Remove(engine);
            this.unitOfWork.Complete();
        }

        public void DeleteEngine(int cylindersNumber)
        {
            Engine engine = this.unitOfWork.Engines.GetByCylindersNumber(cylindersNumber);
            this.unitOfWork.Engines.Remove(engine);
            this.unitOfWork.Complete();
        }

        private ICollection<Car> GetCarsByBrand(ICollection<string> Brands)
        {
            ICollection<Car> cars = new List<Car>();
            foreach (var brand in Brands)
            {
                var car = this.unitOfWork.Cars.GetByBrand(brand);
                if (car != null)
                    cars.Add(car);                
                else
                    throw new Exception("Bad Request parameters");
            }
            return cars;
        }

    }
}
