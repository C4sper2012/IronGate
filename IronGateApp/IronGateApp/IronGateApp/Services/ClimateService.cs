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

        Climate climate;

        public async Task<Climate> GetClimate()
        {
            var response = await client.GetAsync("https://api.thingspeak.com/channels/1916370/feeds.json?api_key=0QYE3TAWD42POHP2&results=8000");

            if (response.IsSuccessStatusCode)
            {
                climate = await response.Content.ReadFromJsonAsync<Climate>();
            }

            return climate;
        }
    }
}
