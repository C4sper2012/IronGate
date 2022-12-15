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
        
        // Temperature API calls
        public async Task<List<Temperature>> GetTemperatureFromFloor(int floor)
        {
            string url = $"{AppConstants.APIAddress}/Temperature/{floor}";
            var client = new RestClient(url);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("content-type", "application/json");
            RestResponse response = client.Execute(request);
            return JsonSerializer.Deserialize<List<Temperature>>(response.Content);
        }

        public async Task<List<Temperature>> GetNewestTemperatureFromFloor(int floor)
        {
            string url = $"{AppConstants.APIAddress}/Temperature/newest/{floor}";
            var client = new RestClient(url);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("content-type", "application/json");
            RestResponse response = client.Execute(request);
            return JsonSerializer.Deserialize<List<Temperature>>(response.Content);
        }
        
        public async Task<List<Temperature>> GetTemperaturesFromDateAndFloor(DateTime dateFrom, int floor)
        {
            string url = $"{AppConstants.APIAddress}/Temperature/{dateFrom.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}/{floor}";
            var client = new RestClient(url);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("content-type", "application/json");
            RestResponse response = client.Execute(request);
            return JsonSerializer.Deserialize<List<Temperature>>(response.Content);
        }
        
        public async Task<List<Temperature>> GetTemperaturesFromDatesAndFloor(DateTime dateFrom, DateTime dateTo, int floor)
        {
            string url = $"{AppConstants.APIAddress}/Temperature/{dateFrom.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}/" +
                         $"{dateTo.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}/{floor}";
            var client = new RestClient(url);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("content-type", "application/json");
            RestResponse response = client.Execute(request);
            return JsonSerializer.Deserialize<List<Temperature>>(response.Content);
        }

        
        // Humidity API calls
        public async Task<List<Humidity>> GetHumidityFromFloor(int floor)
        {
            string url = $"{AppConstants.APIAddress}/Humidity/{floor}";
            var client = new RestClient(url);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("content-type", "application/json");
            RestResponse response = client.Execute(request);
            return JsonSerializer.Deserialize<List<Humidity>>(response.Content);
        }
        
        public async Task<List<Humidity>> GetNewestHumidityFromFloor(int floor)
        {
            string url = $"{AppConstants.APIAddress}/Humidity/newest/{floor}";
            var client = new RestClient(url);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("content-type", "application/json");
            RestResponse response = client.Execute(request);
            return JsonSerializer.Deserialize<List<Humidity>>(response.Content);
        }
        
        public async Task<List<Humidity>> GetHumidityFromDateAndFloor(DateTime dateFrom, int floor)
        {
            string url = $"{AppConstants.APIAddress}/Humidity/{dateFrom.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}/{floor}";
            var client = new RestClient(url);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("content-type", "application/json");
            RestResponse response = client.Execute(request);
            return JsonSerializer.Deserialize<List<Humidity>>(response.Content);
        }

        public async Task<List<Humidity>> GetHumidityFromDatesAndFloor(DateTime dateFrom, DateTime dateTo, int floor)
        {
            string url = $"{AppConstants.APIAddress}/Humidity/{dateFrom.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}/" +
                         $"{dateTo.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}/{floor}";
            var client = new RestClient(url);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("content-type", "application/json");
            RestResponse response = client.Execute(request);
            return JsonSerializer.Deserialize<List<Humidity>>(response.Content);
        }

        
    }
}