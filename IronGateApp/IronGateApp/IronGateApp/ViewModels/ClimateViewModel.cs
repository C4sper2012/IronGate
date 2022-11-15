using CommunityToolkit.Mvvm.Input;
using IronGateApp.Models;
using IronGateApp.Models.Enums;
using IronGateApp.Services;
using IronGateApp.Views;
using System.Diagnostics;

namespace IronGateApp.ViewModels
{

    public partial class ClimateViewModel : BaseViewModel
    {
        private readonly ClimateService _climateService;

        public ClimateViewModel(ClimateService climateService)
        {
            _climateService = climateService;
        }


        public Climate Climate { get; set; } = new();

        [RelayCommand]
        async Task GetClimateAsync()
        {
            try
            {
                Climate = await _climateService.GetClimateAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get climate: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
        }

        [RelayCommand]
        async Task GetFirstFloorClimateAsync()
        {
            try
            {
                Climate = await _climateService.GetFirstFloorClimateAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get climate: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
        }

        [RelayCommand]
        async Task GoToDetails(string index = "")
        {
            switch (index)
            {
                case "0":
                    Climate = await _climateService.GetFirstFloorClimateAsync();
                    Climate.Floor = Floor.FirstFloor;
                    
                    break;
                case "1":
                    Climate = await _climateService.GetGroundFloorClimateAsync();
                    Climate.Floor = Floor.GroundFloor;
                    break;
                case "2":
                    Climate = await _climateService.GetBasementClimateAsync();
                    Climate.Floor = Floor.Basement;
                    break;
                default:
                    break;
            }
            
            if (Climate != null)
            {
                await Shell.Current.GoToAsync(nameof(ClimateDetailsPage), true, new Dictionary<string, object>
                {
                    {"Climate", Climate }
                });
                
            }
        }
    }
}
