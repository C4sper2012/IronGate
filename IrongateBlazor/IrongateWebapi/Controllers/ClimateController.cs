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
        
        [Route("{dateFrom:datetime}")]
        [HttpGet]
        public IEnumerable<Climate> GetClimateById(DateTime dateFrom, DateTime dateTo)
        {
            return new List<Climate>(){new(){ Humidity = 25, Temperature = 25, ID = 1, TimeStamp = DateTime.Now}};
        }
    }
}