using System;
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

        public void DeleteEngine(Guid Id)
        {
            Engine engine = this.unitOfWork.Engines.Get(Id);
            this.unitOfWork.Engines.Remove(engine);
            this.unitOfWork.Complete();
        }

        public EngineDTO GetEngine(Guid Id)
        {
            Engine engine = this.unitOfWork.Engines.Get(Id) as Engine;
            return this.mapper.Map<EngineDTO>(engine);
        }

        public void InsertEngine(EngineDTO engineDTO)
        {
            Engine engine = this.mapper.Map<Engine>(engineDTO);
            engine.EngineId = Guid.NewGuid();
            this.unitOfWork.Engines.Add(engine);
            this.unitOfWork.Complete();
        }

        public void UpdateEngine(EngineDTO engineDTO)
        {
            throw new NotImplementedException();
        }

    }
}
