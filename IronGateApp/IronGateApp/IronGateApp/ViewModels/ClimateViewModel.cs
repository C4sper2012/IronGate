using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IronGateApp.Models;
using IronGateApp.Services;
using IronGateApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronGateApp.ViewModels
{
   
    public partial class ClimateViewModel : BaseViewModel
    {
        private readonly ClimateService _climateService;

        public ClimateViewModel(ClimateService climateService)
        {
            _climateService= climateService;
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
            catch (Exception)
            {

                throw;
            }
        }


        async Task GoToDetails(Climate climate)
        {
            if (climate == null)
                return;

            await Shell.Current.GoToAsync(nameof(ClimateDetailsPage), true, new Dictionary<string, object>
            {
                {"Climate", climate }
            });
        }

    }
}
