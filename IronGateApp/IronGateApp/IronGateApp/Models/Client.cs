using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronGateApp.Models
{
    public class Channel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("field1")]
        public string BasementTemp { get; set; }

        [JsonProperty("field2")]
        public string BasementHumid { get; set; }

        [JsonProperty("field4")]
        public string GroundFloorTemp { get; set; }

        [JsonProperty("field5")]
        public string GroundFloorHumid { get; set; }

        [JsonProperty("field7")]
        public string FirstFloorTemp { get; set; }

        [JsonProperty("field8")]
        public string FirstFloorHumid { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("last_entry_id")]
        public int LastEntryId { get; set; }
    }

    public class Feed
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("entry_id")]
        public int EntryId { get; set; }

        [JsonProperty("field1")]
        public string Field1 { get; set; }

        [JsonProperty("field2")]
        public string Field2 { get; set; }

        [JsonProperty("field4")]
        public string Field4 { get; set; }

        [JsonProperty("field5")]
        public string Field5 { get; set; }

        [JsonProperty("field7")]
        public string Field7 { get; set; }

        [JsonProperty("field8")]
        public string Field8 { get; set; }
    }

    public class Climate
    {
        [JsonProperty("channel")]
        public Channel Channel { get; set; }

        [JsonProperty("feeds")]
        public List<Feed> Feeds { get; set; }
    }
}
