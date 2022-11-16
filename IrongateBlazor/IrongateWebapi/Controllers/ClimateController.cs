using Irongate.Repository.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Irongate.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClimateController : ControllerBase
    {
        [Route("{id:int}")]
        [HttpGet]
        public Climate GetClimateById(int id)
        {
            
            return new Climate();
        }

        [Route("all")]
        [HttpGet]
        public IEnumerable<Climate> GetAllClimates()
        {
            // TODO: Implement
            return new List<Climate>(){new(){ Humidity = 25, Temperature = 25, ID = 1, TimeStamp = DateTime.Now}};
        }
        
        [Route("all/{take:int}")]
        [HttpGet]
        public IEnumerable<Climate> Take(int take)
        {
            // TODO: Implement
            return new List<Climate>(){new(){ Humidity = 25, Temperature = 25, ID = 1, TimeStamp = DateTime.Now}};
        }
        
        [Route("{datefrom:datetime}/{dateTo:datetime}")]
        [HttpGet]
        public IEnumerable<Climate> GetClimateFromToDate(DateTime datefrom, DateTime dateTo)
        {
            // TODO: Implement
            return new List<Climate>(){new(){ Humidity = 25, Temperature = 25, ID = 1, TimeStamp = DateTime.Now}};
        }
        
        [Route("{datefrom:datetime}")]
        [HttpGet]
        public IEnumerable<Climate> GetClimateFromDate(DateTime dateTime)
        {
            // TODO: Implement
            return new List<Climate>(){new(){ Humidity = 25, Temperature = 25, ID = 1, TimeStamp = DateTime.Now}};
        }
    }
}