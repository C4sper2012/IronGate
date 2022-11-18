using System.Text.Json;
using Irongate.Service.Interfaces;
using Irongate.Service.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using RestSharp;

namespace Irongate.Service.Services
{
    public class WaterLevelService : IWaterLevelSevice
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WaterLevelService(IHttpContextAccessor httpContextAccessor) => _httpContextAccessor = httpContextAccessor;

        public async Task<List<WaterLevel>> GetWaterLevel()
        {
            RestClient client = new("http://10.135.16.30/WaterLevel/all/2000");
            RestRequest request = new()
            {
                Method = Method.Get
            };
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", $"Bearer {await _httpContextAccessor.HttpContext.GetTokenAsync("access_token")}");
            RestResponse response = client.Execute(request);

            List<WaterLevel> result = JsonSerializer.Deserialize<List<WaterLevel>>(response.Content);

            return result;
        }
    }
}