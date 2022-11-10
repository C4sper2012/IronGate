using IronGateApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

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
