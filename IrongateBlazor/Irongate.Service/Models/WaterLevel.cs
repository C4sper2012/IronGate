using Newtonsoft.Json;

namespace Irongate.Service.Models
{
    public class WaterLevel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("entryID")]
        public int EntryID { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("timeStamp")]
        public DateTime TimeStamp { get; set; }
    }
}