using Irongate.Repository.Domain.Models;
using Irongate.Service.DTO;

namespace Irongate.Service;


public class ClimateService : IGenericService<ClimateDTO>, IClimateService
{
    private readonly MappingService _mappingService;

    public ClimateService(MappingService mappingService)
    {
        _mappingService = mappingService;
    }
}