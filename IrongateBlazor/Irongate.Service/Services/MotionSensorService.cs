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
            List<MotionSensor> motionSensor = new ();
            // for (int i = 0; i < 10; i++)
            // {
            //     motionSensor.Add(new MotionSensor()
            //     {
            //         EntryID = i, Id = i, Value = 1, TimeStamp = DateTime.Now.AddDays(-i)
            //     });
            // }

            return motionSensor;
            
            var client = new RestClient("http://10.135.16.30/Motion/all/10");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", $"Bearer {await _httpContextAccessor.HttpContext.GetTokenAsync("access_token")}");
            RestResponse response = client.Execute(request);
            return JsonSerializer.Deserialize<List<MotionSensor>>(response.Content);

        }
    }
}


