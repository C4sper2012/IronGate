﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Irongate.WebAPI.Controllers
{
    using global::IrongateWebapi;
    using Microsoft.AspNetCore.Mvc;

    namespace IrongateWebapi.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class HumidityController : ControllerBase
        {
            private readonly ILogger<WeatherForecastController> _logger;

            public HumidityController(ILogger<WeatherForecastController> logger)
            {
                _logger = logger;
            }

            [HttpGet(Name = "GetWeatherForecast")]
            public IEnumerable<WeatherForecast> Get()
            {
            }
        }
    }
}
