using IronGateApp.Models;
using System.Net.Http.Json;

namespace IronGateApp.Services
{
    public class ClimateService
    {

        private readonly HttpClient client;

        public ClimateService()
        {
            this.client = new HttpClient();
        }

        public async Task<Climate> GetClimateAsync()
        {
            Climate climate = await client.GetFromJsonAsync<Climate>("https://api.thingspeak.com/channels/1916370/feeds.json?api_key=0QYE3TAWD42POHP2&results=8000");
            
            return climate;
        }

        public async Task<Climate> GetFirstFloorClimateAsync()
        {
            // TODO: Add Polly
            var temp = await client.GetFromJsonAsync<Climate>("https://api.thingspeak.com/channels/1916370/fields/7.json?api_key=0QYE3TAWD42POHP2&results=100");
            var humid = await client.GetFromJsonAsync<Climate>("https://api.thingspeak.com/channels/1916370/fields/8.json?api_key=0QYE3TAWD42POHP2&results=100");

            temp.Feeds = temp.Feeds.FindAll(f => f.Field7 != null).OrderByDescending(x => x.CreatedAt).ToList();
            humid.Feeds = humid.Feeds.FindAll(h => h.Field8 != null).OrderByDescending(x => x.CreatedAt).ToList();

            Climate climate = temp;
            climate.Feeds.AddRange(humid.Feeds);

            return climate;
        }

        public async Task<Climate> GetBasementClimateAsync()
        {
            // TODO: Add Polly
            var temp = await client.GetFromJsonAsync<Climate>("https://api.thingspeak.com/channels/1916370/fields/1.json?api_key=0QYE3TAWD42POHP2&results=100");
            var humid = await client.GetFromJsonAsync<Climate>("https://api.thingspeak.com/channels/1916370/fields/2.json?api_key=0QYE3TAWD42POHP2&results=100");

            temp.Feeds = temp.Feeds.FindAll(f => f.Field1 != null).OrderByDescending(x => x.CreatedAt).ToList();
            humid.Feeds = humid.Feeds.FindAll(h => h.Field2 != null).OrderByDescending(x => x.CreatedAt).ToList();

            Climate climate = temp;
            climate.Feeds.AddRange(humid.Feeds);

            return climate;
        }

        public async Task<Climate> GetGroundFloorClimateAsync()
        {
            // TODO: Add Polly
            var temp = await client.GetFromJsonAsync<Climate>("https://api.thingspeak.com/channels/1916370/fields/4.json?api_key=0QYE3TAWD42POHP2&results=100");
            var humid = await client.GetFromJsonAsync<Climate>("https://api.thingspeak.com/channels/1916370/fields/5.json?api_key=0QYE3TAWD42POHP2&results=100");

            temp.Feeds = temp.Feeds.FindAll(f => f.Field4 != null).OrderByDescending(x => x.CreatedAt).ToList();
            humid.Feeds = humid.Feeds.FindAll(h => h.Field5 != null).OrderByDescending(x => x.CreatedAt).ToList();

            Climate climate = temp;
            climate.Feeds.AddRange(humid.Feeds);

            return climate;
        }
    }
}
