using Irongate.Service.Models;
using Irongate.Service.Models.Enum;

namespace Irongate.Service.Interfaces
{
    public interface IClimateService
    {
        public Task<List<Climate>> GetClimates(DateTime time, int floor);
    }
}