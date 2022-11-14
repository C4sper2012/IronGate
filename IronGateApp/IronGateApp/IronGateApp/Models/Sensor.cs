using Newtonsoft.Json;

namespace IronGateApp.Models
{
    public class Sensor
    {
        [JsonProperty("channel")]
        public Channel Channel { get; set; }

        [JsonProperty("feeds")]
        public List<Feed> Feeds { get; set; }
    }
}