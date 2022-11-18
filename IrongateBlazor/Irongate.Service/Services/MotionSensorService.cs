using Irongate.Service.Models;
using Irongate.Service.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using RestSharp;

namespace Irongate.Service.Services
{
    public class MotionSensorService : IMotionSensorService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MotionSensorService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<MotionSensor>> GetSensor()
        {
            var client = new RestClient("http://10.135.16.30/Sensor/all");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", $"Bearer {await _httpContextAccessor.HttpContext.GetTokenAsync("access_token")}");
            RestResponse response = client.Execute(request);
            return JsonSerializer.Deserialize<List<MotionSensor>>(response.Content);
        }
    }
}


