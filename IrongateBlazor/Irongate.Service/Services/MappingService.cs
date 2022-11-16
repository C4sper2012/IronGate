
using AutoMapper;
using Irongate.Repository.Domain.Models;
using Irongate.Service.Base;
using Irongate.Service.DTO;

namespace Irongate.Service;

public class MappingService : BaseService
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
            LogInformation("Successfully created mappings");
        }
        catch (Exception ex)
        {
          LogError("Failed to create mappings", ex);
        }
    }
}