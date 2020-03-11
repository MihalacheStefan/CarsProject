﻿using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Repository;
using Repository.Interfaces.UnitOfWork;
using Repository.UnitOfWork;
using Service.Interfaces;
using Service.Services;
using Infrastructure.AutoMapper;

namespace Infrastructure
{
    public class ServicesInfrastructure
    {
        private IServiceCollection services;
        private Autofac.ContainerBuilder builder;
        private Autofac.IContainer container;
        private IMapper mapper;


        public ServicesInfrastructure(IServiceCollection services)
        {
            this.services = services;
            this.builder = new Autofac.ContainerBuilder();
        }
        public void ConfigureServices()
        {

            this.services.AddDbContext<AplicationContext>();

            var mappingConfig = new MapperConfiguration(mc =>               // Auto Mapper Configurations
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            this.mapper = mapper;
            this.services.AddSingleton(mapper);


            this.services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        private void RegisterBuilder()
        {
            this.builder.Populate(this.services);

            this.builder.Register((c,p)=> new DbContextOptions<AplicationContext>());
            this.builder.RegisterType<AplicationContext>();
            this.builder.Register((c,p) => 
                 new UnitOfWork(c.Resolve<AplicationContext>()))
                 .As<IUnitOfWork>();

            this.builder.Register((c, p) =>
                new CarService(c.Resolve<IUnitOfWork>(), this.mapper))
                .As<ICarService>();

            this.builder.Register((c, p) =>
                new ChassisService(c.Resolve<IUnitOfWork>(), this.mapper))
                .As<IChassisService>();

            this.builder.Register((c, p) =>
                new EngineService(c.Resolve<IUnitOfWork>(), this.mapper))
                .As<IEngineService>();

        }
        public void CreateContainer()
        {
            RegisterBuilder();
            this.container = this.builder.Build();
        }

        public IServiceProvider GetServiceProvider()
        {
            return this.container.Resolve<IServiceProvider>();
        }
        public Autofac.IContainer GetContainer()
        {
            return this.container;
        }
    }

}
