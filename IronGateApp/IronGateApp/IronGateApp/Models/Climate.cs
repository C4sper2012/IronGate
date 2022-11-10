using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronGateApp.Models
{
    public class Climate
    {
        public string Temperature { get; set; } = "25";
        public string Humidity { get; set; } = "60";
        public int? WaterLevel { get; set; } = 1;
    }
}
