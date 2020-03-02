﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Service;

namespace Infrastructure
{
    public class ServicesInfrastructure
    {
        private IServiceCollection _services;
       // private AplicationContext _context;
        private ServiceProvider _serviceProvider;

        public ServicesInfrastructure(IServiceCollection services)
        {
            _services = services;
            _serviceProvider = services.BuildServiceProvider();
        }
        public void AddDbContext()
        {
            _services.AddDbContext<AplicationContext>();
            //_context = _serviceProvider.GetRequiredService<AplicationContext>();   
        }
        //public AplicationContext GetContext()
        //{
        //    return _context;
        //}
        public void ConfigureMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>               // Auto Mapper Configurations
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _services.AddSingleton(mapper);
        }
        
    }

}