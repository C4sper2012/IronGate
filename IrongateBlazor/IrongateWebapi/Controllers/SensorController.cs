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
        public MotionSensor GetClimateById(int id)
        {
            return new MotionSensor();
        }
    }
}