using IronGateApp.Models;

namespace IronGateApp.ViewModels
{
    public class MainPageViewModel
    {
        public List<RoomDHT11> Data { get; set; }
        public MainPageViewModel()
        {
            Data = new List<RoomDHT11>()
            {
                new RoomDHT11 { Floor = "Basement", Temperature = 23, Humidity = 46 },
                new() { Floor = "Ground floor", Temperature = 24, Humidity = 51 },
                new() { Floor = "First floor", Temperature = 23, Humidity = 48 }
            };
        }
    }
}