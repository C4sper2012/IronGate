using Newtonsoft.Json;

namespace IronGateApp.Models
{
    public class WindowControl
    {
        [JsonProperty("channel")]
        public Channel Channel { get; set; }

        [JsonProperty("feeds")]
        public List<WindowFeed> Feeds { get; set; }
    }

    public class WindowChannel
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
        public string BasementWindow { get; set; }

        [JsonProperty("field3")]
        public string GroundFloorWindow { get; set; }

        [JsonProperty("field5")]
        public string FirstFloorWindow { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("last_entry_id")]
        public int LastEntryId { get; set; }
    }

    public class WindowFeed
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("entry_id")]
        public int EntryId { get; set; }

        [JsonProperty("field1")]
        public string Field1 { get; set; }

        [JsonProperty("field3")]
        public string Field3 { get; set; }

        [JsonProperty("field5")]
        public string Field5 { get; set; }
    }
}
