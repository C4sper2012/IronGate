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
        async Task GoToDetails(string index = "")
        {
            if (Climates == null)
                return;

            List<Feed> feeds;

            switch (index)
            {
                case "0":
                    //feeds = Climates.Select(c => c.Feeds.OrderByDescending(o => o.CreatedAt)).FirstOrDefault().Single(f => f.Field1 != null & f.Field2 != null); 
                    break;
                default:
                    break;
            }


            await Shell.Current.GoToAsync(nameof(ClimateDetailsPage), true, new Dictionary<string, object>
            {
                {"Climate", Climates }
            });
        }

    }
}
