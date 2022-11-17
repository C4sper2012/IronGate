using System.Text.Json;
using Irongate.Service.Interfaces;
using Irongate.Service.Models;
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
        
        public async Task<List<Climate>> GetClimates()
        {
            var client = new RestClient("http://10.135.16.30/Climate/all/5");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", $"Bearer {await _httpContextAccessor.HttpContext.GetTokenAsync("access_token")}");
            RestResponse response = client.Execute(request);
            return JsonSerializer.Deserialize<List<Climate>>(response.Content);
        }
    }
}