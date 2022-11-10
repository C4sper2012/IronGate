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

        List<Climate> climates;

        public async Task<List<Climate>> GetClimate()
        {
            var response = await client.GetAsync("https://api.thingspeak.com/channels/1916370/feeds.json?api_key=0QYE3TAWD42POHP2");
            if (response.IsSuccessStatusCode)
            {
                climates = await response.Content.ReadFromJsonAsync<List<Climate>>();
            }
            return climates;
        }
    }
}
