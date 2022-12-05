using Irongate.Service.Constants;
using Irongate.Service.Interfaces;
using Irongate.Service.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;

namespace Irongate.Service.Services
{
    public class LogService : ILogService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task CreateAsync(Log log)
        {
            try
            {
                var client = new RestClient($"http://{AppConstants.DatabaseAddress}/Log/Create");
                var request = new RestRequest();
                request.Method = Method.Post;
                request.AddHeader("content-type", "application/json");
                request.AddHeader("authorization",
                    $"Bearer {await _httpContextAccessor.HttpContext.GetTokenAsync("access_token")}");
                request.AddJsonBody(JsonConvert.SerializeObject(log));
                RestResponse response = client.Execute(request);
            }
            catch (Exception e)
            {
                
            }
        }
        
        public async Task DeleteAsync()
        {
            var client = new RestClient($"http://{AppConstants.DatabaseAddress}/Log/Clear");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization",
                $"Bearer {await _httpContextAccessor.HttpContext.GetTokenAsync("access_token")}");
            RestResponse response = client.Execute(request);
        }

        public async Task<List<Log>> GetLogs()
        {
            try
            {
                var client = new RestClient($"http://{AppConstants.DatabaseAddress}/Log/all");
                var request = new RestRequest();
                request.Method = Method.Get;
                request.AddHeader("content-type", "application/json");
                request.AddHeader("authorization", $"Bearer {await _httpContextAccessor.HttpContext.GetTokenAsync("access_token")}");
                RestResponse response = await client.ExecuteAsync(request);
                return JsonConvert.DeserializeObject<List<Log>>(response.Content);
            }
            catch (Exception e)
            {
                return new List<Log>();
            }
        }
    }
}