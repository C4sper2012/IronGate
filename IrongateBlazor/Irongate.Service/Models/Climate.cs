using Irongate.Service.Models.Enum;
using Newtonsoft.Json;

namespace Irongate.Service.Models
{
    public class Climate
    {
        public int id { get; set; }

        public int entryID { get; set; }
        public DateTime timeStamp { get; set; }

        public Floor floor { get; set; }

         public int temperature { get; set; }

        public int humidity { get; set; }
    }
}