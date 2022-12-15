using System.Globalization;
using System.Text.Json;
using Irongate.Service.Constants;
using Irongate.Service.Interfaces;
using Irongate.Service.Models;
using Irongate.Service.Models.Enum;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using RestSharp;


namespace Irongate.Service.Services
{
    public class ClimateService : IClimateService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClimateService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<List<Climate>> GetClimates(DateTime dateTime, int floor)
        {
            string url = $"{AppConstants.APIAddress}/Climate/{dateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}/{floor}";
            var client = new RestClient(url);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", $"Bearer {await _httpContextAccessor.HttpContext.GetTokenAsync("access_token")}");
            RestResponse response = client.Execute(request);
            var climates = JsonSerializer.Deserialize<List<Climate>>(response.Content);
            return climates.FindAll(x => x.humidity != 0 && x.temperature != 0).ToList();
        }
        
    }
}