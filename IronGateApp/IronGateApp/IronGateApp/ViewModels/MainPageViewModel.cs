using CommunityToolkit.Mvvm.ComponentModel;
using IronGateApp.Models;
using IronGateApp.Services;
using System.Collections.ObjectModel;

namespace IronGateApp.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private int waterLevel;

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
    }
}