using IronGateApp.Models;
using System.Net.Http.Json;

namespace IronGateApp.Services
{
    public class HomePageChartService
    {
        private readonly HttpClient _client;
        public HomePageChartService()
        {
            _client = new HttpClient();
        }

        public async Task<List<RoomDHT11>> GetChartDataFromRestAPIAsync()
        {
            List<RoomDHT11> chartData = new();
            Climate climate = await _client.GetFromJsonAsync<Climate>("https://api.thingspeak.com/channels/1916370/feeds.json?api_key=0QYE3TAWD42POHP2&results=3");

            foreach (Feed feed in climate.Feeds)
            {
                RoomDHT11 newRoomDHT11 = new();

                if (feed.Field1 != null)
                {
                    newRoomDHT11 = new()
                    {
                        Floor = "Basement",
                        Temperature = Convert.ToInt32(feed.Field1),
                        Humidity = Convert.ToInt32(feed.Field2)
                    };
                }
                else if (feed.Field4 != null)
                {
                    newRoomDHT11 = new()
                    {
                        Floor = "Ground floor",
                        Temperature = Convert.ToInt32(feed.Field4),
                        Humidity = Convert.ToInt32(feed.Field5)
                    };
                }
                else if (feed.Field7 != null)
                {
                    newRoomDHT11 = new()
                    {
                        Floor = "First floor",
                        Temperature = Convert.ToInt32(feed.Field7),
                        Humidity = Convert.ToInt32(feed.Field8)
                    };
                }

                chartData.Add(newRoomDHT11);
            }

            return chartData;
        }

        public async Task<int> GetWaterLevelFromRestAPIAsync()
        {
            Sensor sensor = await _client.GetFromJsonAsync<Sensor>("https://api.thingspeak.com/channels/1916393/fields/1.json?api_key=5SUJCFNTGZ25ODE6&results=1");
            return Convert.ToInt32(sensor.Feeds.First().Field1);
        }
    }
}