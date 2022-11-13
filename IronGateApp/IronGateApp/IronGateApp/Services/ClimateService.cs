using IronGateApp.Models;
using System.Net.Http.Json;
using Polly;

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
            var tempResponse = await GetUrlResultFromPollyAsync("https://api.thingspeak.com/channels/1916370/fields/7.json?api_key=0QYE3TAWD42POHP2&results=100");
            var humidResponse = await GetUrlResultFromPollyAsync("https://api.thingspeak.com/channels/1916370/fields/8.json?api_key=0QYE3TAWD42POHP2&results=100");

            Climate tempClimate = await tempResponse.Content.ReadFromJsonAsync<Climate>();
            Climate humidClimate = await humidResponse.Content.ReadFromJsonAsync<Climate>();

            tempClimate.Feeds = tempClimate.Feeds.FindAll(f => f.Field7 != null).OrderByDescending(x => x.CreatedAt).ToList();
            humidClimate.Feeds = humidClimate.Feeds.FindAll(h => h.Field8 != null).OrderByDescending(x => x.CreatedAt).ToList();

            tempClimate.Feeds.AddRange(humidClimate.Feeds);

            return tempClimate;
        }

        public async Task<Climate> GetBasementClimateAsync()
        {

            var tempResponse = await GetUrlResultFromPollyAsync("https://api.thingspeak.com/channels/1916370/fields/1.json?api_key=0QYE3TAWD42POHP2&results=100");
            var humidResponse = await GetUrlResultFromPollyAsync("https://api.thingspeak.com/channels/1916370/fields/2.json?api_key=0QYE3TAWD42POHP2&results=100");

            Climate tempClimate = await tempResponse.Content.ReadFromJsonAsync<Climate>();
            Climate humidClimate = await humidResponse.Content.ReadFromJsonAsync<Climate>();

            tempClimate.Feeds = tempClimate.Feeds.FindAll(f => f.Field1 != null).OrderByDescending(x => x.CreatedAt).ToList();
            humidClimate.Feeds = humidClimate.Feeds.FindAll(h => h.Field2 != null).OrderByDescending(x => x.CreatedAt).ToList();
            

            tempClimate.Feeds.AddRange(humidClimate.Feeds);

            return tempClimate;
        }

        private async Task<HttpResponseMessage> GetUrlResultFromPollyAsync(string url)
        {
           return await Policy
            .HandleResult<HttpResponseMessage>(ex => !ex.IsSuccessStatusCode)
            .WaitAndRetryAsync(retryCount: 3, sleepDurationProvider:
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                onRetry: (ex, time) =>
                {
                    Console.WriteLine($"Something went wrong: {ex.Exception},retrying...");
                })
            .ExecuteAsync(async () =>
            {
                return await client.GetAsync(url);
            });
        }

        public async Task<Climate> GetGroundFloorClimateAsync()
        {
            var tempResponse = await GetUrlResultFromPollyAsync("https://api.thingspeak.com/channels/1916370/fields/4.json?api_key=0QYE3TAWD42POHP2&results=100");
            var humidResponse = await GetUrlResultFromPollyAsync("https://api.thingspeak.com/channels/1916370/fields/5.json?api_key=0QYE3TAWD42POHP2&results=100");

            Climate tempClimate = await tempResponse.Content.ReadFromJsonAsync<Climate>();
            Climate humidClimate = await humidResponse.Content.ReadFromJsonAsync<Climate>();

            tempClimate.Feeds = tempClimate.Feeds.FindAll(f => f.Field4 != null).OrderByDescending(x => x.CreatedAt).ToList();
            humidClimate.Feeds = humidClimate.Feeds.FindAll(h => h.Field5 != null).OrderByDescending(x => x.CreatedAt).ToList();

            tempClimate.Feeds.AddRange(humidClimate.Feeds);

            return tempClimate;
        }
    }
}
