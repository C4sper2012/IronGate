using CommunityToolkit.Mvvm.ComponentModel;
using IronGateApp.Models;
using IronGateApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronGateApp.ViewModels
{
    [QueryProperty(nameof(Climate), "Climate")]
    public partial class ClimateDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        Climate climate;

        [ObservableProperty]
        int temperature;

        [ObservableProperty]
        int humidity;

        public void AssignTemperatureAndHumidity()
        {
            try
            {
                switch (climate.Floor)
                {
                    case Floor.Basement:
                        Temperature = Convert.ToInt32(Climate.Feeds.Select(x => x.Field1).FirstOrDefault(x => x != null));
                        Humidity = Convert.ToInt32(Climate.Feeds.Select(x => x.Field2).FirstOrDefault(x => x != null));
                        break;
                    case Floor.GroundFloor:
                        Temperature = Convert.ToInt32(Climate.Feeds.Select(x => x.Field4).FirstOrDefault(x => x != null));
                        Humidity = Convert.ToInt32(Climate.Feeds.Select(x => x.Field5).FirstOrDefault(x => x != null));
                        break;
                    case Floor.FirstFloor:
                        Temperature = Convert.ToInt32(Climate.Feeds.Select(x => x.Field7).FirstOrDefault(x => x != null));
                        Humidity = Convert.ToInt32(Climate.Feeds.Select(x => x.Field8).FirstOrDefault(x => x != null));
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                temperature = 0;
                humidity = 0;
            }
            
        }
    }
}
