using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IronGateApp.Models;
using IronGateApp.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace IronGateApp.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private int waterLevel;

        [ObservableProperty]
        private bool isRefreshing;

        public ObservableCollection<RoomDHT11> Data { get; set; } = new();

        private readonly HomePageChartService _homePageChartService;
        public MainPageViewModel(HomePageChartService homePageChartService)
        {
            _homePageChartService = homePageChartService;
        }

        public async Task GetChartData()
        {
            Data.Clear();
            foreach (RoomDHT11 dHT11 in await _homePageChartService.GetChartDataFromRestAPIAsync())
            {
                Data.Add(dHT11);
            }
        }

        public async Task<int> GetSensorDataAsync() => await _homePageChartService.GetWaterLevelFromRestAPIAsync();

        [RelayCommand]
        private async Task UpdateData()
        { 
            try
            {
                WaterLevel = await GetSensorDataAsync();
                await GetChartData();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to update data: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsRefreshing = false;
            }
            
        }
    }
}