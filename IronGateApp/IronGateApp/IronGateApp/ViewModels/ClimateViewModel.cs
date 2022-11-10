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


        public Climate Climate { get; set; } = new();

        [RelayCommand]
        async Task GetClimateAsync()
        {
            try
            {
                Climate = await _climateService.GetClimate();
            }
            catch (Exception)
            {

                throw;
            }
        }


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
