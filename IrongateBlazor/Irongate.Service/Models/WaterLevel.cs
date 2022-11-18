using Newtonsoft.Json;

namespace Irongate.Service.Models
{
    public class WaterLevel
    {
        public int id { get; set; }
        public int entryID { get; set; }
        public int value { get; set; }
        public DateTime timeStamp { get; set; }


        //[JsonProperty("id")]
        //public int Id { get; set; }

        //[JsonProperty("entryID")]
        //public int EntryID { get; set; }

        //[JsonProperty("value")]
        //public int Value { get; set; }

        //[JsonProperty("timeStamp")]
        //public DateTime TimeStamp { get; set; }
    }
}