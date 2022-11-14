using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronGateApp.Models
{
    public class SensorChannel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string field1 { get; set; }
        public string field4 { get; set; }
        public string field7 { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int last_entry_id { get; set; }
    }

    public class SensorFeed
    {
        public DateTime created_at { get; set; }
        public int entry_id { get; set; }
        public object field4 { get; set; }
    }

    public class MotionSensor
    {
        public Channel channel { get; set; }
        public List<SensorFeed> feeds { get; set; }
    }

}

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
