using AutoMapper;

namespace CodePulse.Application.Interfaces;

public interface IBaseService
{
    IMapper Mapper { get; }
}