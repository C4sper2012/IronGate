using Irongate.Repository.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Irongate.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorController : ControllerBase
    {
        [Route("{id:int}")]
        [HttpGet]
        public MotionSensor GetSensorById(int id)
        {
            
            return new MotionSensor();
        }

        [Route("all")]
        [HttpGet]
        public IEnumerable<MotionSensor> GetAllSensors()
        {
            // TODO: Implement
            return new List<MotionSensor>(){new(){ Value = 1, ID = 1, TimeStamp = DateTime.Now}};
        }
        
        [Route("all/{take:int}")]
        [HttpGet]
        public IEnumerable<MotionSensor> Take(int take)
        {
            // TODO: Implement
            return new List<MotionSensor>(){new(){ Value = 1, ID = 1, TimeStamp = DateTime.Now}};
        }
        
        [Route("{datefrom:datetime}/{dateTo:datetime}")]
        [HttpGet]
        public IEnumerable<MotionSensor> GetSensorFromToDate(DateTime datefrom, DateTime dateTo)
        {
            // TODO: Implement
            return new List<MotionSensor>(){new(){ Value = 1, ID = 1, TimeStamp = DateTime.Now}};
        }
        
        [Route("{datefrom:datetime}")]
        [HttpGet]
        public IEnumerable<MotionSensor> GetSensorFromDate(DateTime dateTime)
        {
            // TODO: Implement
            return new List<MotionSensor>(){new(){ Value = 1, ID = 1, TimeStamp = DateTime.Now}};
        }
    }
}