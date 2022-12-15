using Irongate.Service.Models;

namespace Irongate.Service.Interfaces
{
    public interface IClimateService
    {
        public Task<List<Temperature>> GetTemperatureFromFloor(int floor);
        public Task<List<Temperature>> GetNewestTemperatureFromFloor(int floor);
        public Task<List<Temperature>> GetTemperaturesFromDateAndFloor(DateTime dateFrom, int floor);
        public Task<List<Temperature>> GetTemperaturesFromDatesAndFloor(DateTime dateFrom, DateTime dateTo, int floor);


        // Humidity API calls
        public Task<List<Humidity>> GetHumidityFromFloor(int floor);
        public Task<List<Humidity>> GetNewestHumidityFromFloor(int floor);
        public Task<List<Humidity>> GetHumidityFromDateAndFloor(DateTime dateFrom, int floor);
        public Task<List<Humidity>> GetHumidityFromDatesAndFloor(DateTime dateFrom, DateTime dateTo, int floor);


    }
}