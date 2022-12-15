using Irongate.Service.Models;

namespace Irongate.Service.Interfaces
{
    public interface IClimateService
    {
        public Task<List<Climate>> GetClimates(DateTime time, int floor);
    }
}