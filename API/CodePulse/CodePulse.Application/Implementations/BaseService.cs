using AutoMapper;
using CodePulse.Application.Interfaces;
using CodePulse.Application.MappingProfiles;

namespace CodePulse.Application.Implementations;

public class BaseService : IBaseService
{
    public IMapper Mapper { get; } = new Mapper(new MapperConfiguration(cfg =>
    {
        cfg.AddMaps(typeof(BaseProfile).Assembly);
    }));
}