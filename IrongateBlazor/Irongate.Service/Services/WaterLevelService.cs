using System.Globalization;
using System.Text.Json;
using Irongate.Service.Constants;
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

        public async Task<List<WaterLevel>> GetWaterLevel(DateTime dateTime)
        {
            var client = new RestClient($"{AppConstants.APIAddress}/WaterLevel/{dateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("content-type", "application/json");
            RestResponse response = client.Execute(request);
            return JsonSerializer.Deserialize<List<WaterLevel>>(response.Content);
             
        }
    }
}