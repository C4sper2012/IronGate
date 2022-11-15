
using AutoMapper;
using Irongate.Repository.Domain.Models;
using Irongate.Service.DTO;
using Org.BouncyCastle.Crypto.Utilities;

namespace Irongate.Service;

public class MappingService
{
    public readonly IMapper _mapper;

    public MappingService()
    {
        MapperConfiguration mapperConfig = new MapperConfiguration(cfg =>        
        {    
            //Climate
            cfg.CreateMap<Climate, ClimateDTO>();
            cfg.CreateMap<ClimateDTO, Climate>();
            
            //Log
            cfg.CreateMap<Log, LogDTO>();
            cfg.CreateMap<LogDTO, Log>();
            
            //MotionSensor 
            cfg.CreateMap<MotionSensor, MotionSensorDTO>();
            cfg.CreateMap<MotionSensorDTO, MotionSensor>();
            
            //WaterLevel
            cfg.CreateMap<WaterLevel, WaterLevelDTO>();
            cfg.CreateMap<WaterLevelDTO, WaterLevel>();
        });

        try
        {
            _mapper.ConfigurationProvider.CreateMapper();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}