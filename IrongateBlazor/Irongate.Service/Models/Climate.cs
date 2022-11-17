using Irongate.Service.Models.Enum;
using Newtonsoft.Json;

namespace Irongate.Service.Models
{
    public class Climate
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("entryID")] public int EntryID { get; set; }

        [JsonProperty("timeStamp")] public DateTime TimeStamp { get; set; }

        [JsonProperty("floor")] public Floor Floor { get; set; }

        [JsonProperty("temperature")] public int Temperature { get; set; }

        [JsonProperty("humidity")] public int Humidity { get; set; }
    }
}