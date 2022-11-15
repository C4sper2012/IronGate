using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Irongate.Repository.Domain.Models
{
    public class WaterLevel
    {
        public int ID { get; set; }
        public int Value { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
