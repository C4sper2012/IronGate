using Irongate.Service.DTO;

namespace Irongate.Service;

public interface IClimateService : IGenericService<ClimateDTO>
{
    Task<ClimateDTO> GetById(int id);
    Task<List<ClimateDTO>> GetAll();
}