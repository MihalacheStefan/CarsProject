using AutoMapper;
using Infrastructure.AutoMapper;

namespace Infrastructure.Tests.Mappings
{
    public class MappingTestsFixture
    { 
        public MappingTestsFixture()
        {
            ConfigurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = ConfigurationProvider.CreateMapper();
        }
        public IConfigurationProvider ConfigurationProvider { get; }

        public IMapper Mapper { get; }

    }
}
