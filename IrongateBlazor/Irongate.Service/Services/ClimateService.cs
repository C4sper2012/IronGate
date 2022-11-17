using System.Text.Json;
using Irongate.Service.Interfaces;
using Irongate.Service.Models;
using RestSharp;

namespace Irongate.Service.Services
{
    public class ClimateService : IClimateService
    {
        public List<Climate> GetClimates(string accessToken)
        {
            var client = new RestClient("http://10.135.16.30/Climate/all/5");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", $"Bearer {accessToken}");
            RestResponse response = client.Execute(request);
            return JsonSerializer.Deserialize<List<Climate>>(response.Content);
        }
    }
}