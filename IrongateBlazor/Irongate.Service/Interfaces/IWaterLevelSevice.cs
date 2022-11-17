using Irongate.Service.Models;

namespace Irongate.Service.Interfaces;

public interface IWaterLevelSevice
{
    public Task<List<WaterLevel>> GetWaterLevel();
}