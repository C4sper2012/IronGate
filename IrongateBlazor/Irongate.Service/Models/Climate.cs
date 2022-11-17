using Irongate.Service.Models.Enum;

namespace Irongate.Service.Models
{
    public class Climate
    {
        public int ID { get; set; }
        public int EntryID { get; set; }
        public DateTime TimeStamp { get; set; }
        public Floor Floor { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
    }
}