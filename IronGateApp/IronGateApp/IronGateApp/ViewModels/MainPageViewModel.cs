using CommunityToolkit.Mvvm.Input;
using IronGateApp.Models;
using IronGateApp.Services;
using System.Collections.ObjectModel;

namespace IronGateApp.ViewModels;
public partial class MainPageViewModel : BaseViewModel
{
    public ObservableCollection<RoomDHT11> Data { get; set; } = new();

    private readonly ClimateService _climateService;
    public MainPageViewModel(ClimateService climateService)
    {
        _climateService = climateService;
        Task<ObservableCollection<RoomDHT11>> task = GetChartData();
        Data = task.Result;
    }

    //[RelayCommand]
    private async Task<ObservableCollection<RoomDHT11>> GetChartData()
    {
        ObservableCollection<RoomDHT11> tmpData = new();
        Climate climateBasement = await _climateService.GetBasementClimateAsync();
        tmpData.Add(new()
        {
            Floor = "Basement",
            Temperature = Convert.ToInt32(climateBasement.Feeds.Select(x => x.Field1).FirstOrDefault(x => x != null))
        });

        Climate climateGroundFloor = await _climateService.GetGroundFloorClimateAsync();
        tmpData.Add(new()
        {
            Floor = "Ground floor",
            Temperature = Convert.ToInt32(climateGroundFloor.Feeds.Select(x => x.Field4).FirstOrDefault(x => x != null))
        });

        Climate climateFirstFloor = await _climateService.GetFirstFloorClimateAsync();
        tmpData.Add(new()
        {
            Floor = "First floor",
            Temperature = Convert.ToInt32(climateFirstFloor.Feeds.Select(x => x.Field7).FirstOrDefault(x => x != null))
        });

        return tmpData;
    }
}