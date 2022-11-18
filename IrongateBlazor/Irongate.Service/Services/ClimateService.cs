using System.Text.Json;
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
        
        public async Task<List<Climate>> GetClimates(int floor)
        {
            string dateTime = DateTime.Now.AddDays(-3).ToUniversalTime().ToString("yyyy-MM-dd'T'00:00:00K");
            //var client = new RestClient($"http://10.135.16.30/Climate/{DateTime.Now.AddDays(-3).ToUniversalTime().ToString("yyyy-MM-dd'T'00:00:00K")}/{DateTime.Now.AddDays(-3).ToUniversalTime().ToString("yyyy-MM-dd'T'00:00:00K")}/{floor}");
            var client = new RestClient($"http://10.135.16.30/Climate/2022-11-10T00%3A00%3A00Z/2022-11-20T00%3A00%3A00Z/" + floor);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", $"Bearer {await _httpContextAccessor.HttpContext.GetTokenAsync("access_token")}");
            RestResponse response = client.Execute(request);
            var climates = JsonSerializer.Deserialize<List<Climate>>(response.Content);
            //return climates.FindAll(x => x.humidity != 0 && x.temperature != 0).DistinctBy(x => x.timeStamp.Date).ToList();
            return climates.FindAll(x => x.humidity != 0 && x.temperature != 0).ToList();
        }
        
    }
}