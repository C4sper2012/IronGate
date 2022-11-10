using CommunityToolkit.Mvvm.Input;
using IronGateApp.Models;
using IronGateApp.Services;
using IronGateApp.Views;
using System.Collections.ObjectModel;
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
                Climate = await _climateService.GetClimate();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get climate: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {

            }
        }

        [RelayCommand]
        async Task GoToDetails(string index = "")
        {
            if (Climates == null)
                return;

        async Task GoToDetails(int index)
        {
            if (Climate == null)
                return;

            await Shell.Current.GoToAsync(nameof(ClimateDetailsPage), true, new Dictionary<string, object>
            {
                {"Climate", Climate }
            });
        }

    }
}
