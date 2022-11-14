using IronGateApp.Models;
using System.Net.Http.Json;

namespace IronGateApp.Services
{
    public class SensorService
    {
        private readonly HttpClient client;

        public SensorService()
        {
            this.client = new HttpClient();
        }

        public async Task<List<SensorFeed>> GetSensorAsync()
        {
            MotionSensor sensor = await client.GetFromJsonAsync<MotionSensor>("https://api.thingspeak.com/channels/1916393/fields/4.json?api_key=5SUJCFNTGZ25ODE6&results=8000");
            
            return sensor.feeds.FindAll(x => x.field4 != null).OrderByDescending(x => x.created_at).ToList();
        }
    }
}
