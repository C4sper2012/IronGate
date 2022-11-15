using CommunityToolkit.Mvvm.Input;
using IronGateApp.Models;
using IronGateApp.Services;
using System.Collections.ObjectModel;

namespace IronGateApp.ViewModels
{
    public partial class SensorViewModel : BaseViewModel
    {
        SensorService _sensorService;
        public SensorViewModel(SensorService sensorService)
        {
            _sensorService = sensorService;
        }

        public ObservableCollection<SensorFeed> Sensors { get; set; } = new();

        [RelayCommand]
        async Task GetSensorAsync()
        {
            try
            {
                Sensors.Clear();

                var sensorEntries =  await _sensorService.GetSensorAsync();
                foreach (var item in sensorEntries)
                {
                    item.created_at = item.created_at.AddHours(1);
                    item.field4 = "MOTION DETECTED";
                    Sensors.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                IsRefreshing = false;
            }
        }
    }
}
 