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


        public ObservableCollection<Climate> Climates { get; set; } = new();

        [RelayCommand]
        async Task GetClimateAsync()
        {
            try
            {
                var climates = await _climateService.GetClimate();

                if (climates != null)
                    Climates.Clear();

                foreach (var climate in climates)
                    Climates.Add(climate);
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
        async Task GoToDetails()
        {
            if (Climates == null)
                return;

            await Shell.Current.GoToAsync(nameof(ClimateDetailsPage), true, new Dictionary<string, object>
            {
                {"Climate", Climates }
            });
        }

    }
}
