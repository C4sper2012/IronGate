using Irongate.Service.Models;

namespace Irongate.Service.Interfaces {
    public interface IMotionSensorService
    {
        public Task<List<MotionSensor>> GetSensor();
    }
}

