using Irongate.Service.Models;

namespace Irongate.Service.Interfaces
{
    public interface IClimateService
    {
        public List<Climate> GetClimates(string accessToken);
    }
}