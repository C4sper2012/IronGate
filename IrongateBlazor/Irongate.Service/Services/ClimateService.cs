using Irongate.Repository.Domain.Models;
using Irongate.Repository.Interfaces;
using Irongate.Repository.Repository;
using Irongate.Service.DTO;

namespace Irongate.Service;


public class ClimateService : IGenericService<ClimateDTO, IClimateRepository, Climate>, IClimateService
{
    private readonly IClimateRepository _climateRepository;
    private readonly MappingService _mappingService;
    public ClimateService(IClimateRepository genericRepository, MappingService mappingService) : base(genericRepository, mappingService)
    {
        _climateRepository = genericRepository;
        _mappingService = mappingService;
    }


    public async Task<ClimateDTO> GetById(int id)
    {
        if (id == 0)
        {
            
            return null;
        }
        try
        {
            ClimateDTO result = _mappingService._mapper.Map<ClimateDTO>(await _climateRepository.GetById(id));
            return result;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<List<ClimateDTO>> GetAll()
    {
        try
        {
            List<ClimateDTO> result = _mappingService._mapper.Map<List<ClimateDTO>>(await _climateRepository.GetAll());
            return result;
        }
        catch (Exception e)
        {
            return null;
        }
    }
    
    
    
    
    
    
    
}