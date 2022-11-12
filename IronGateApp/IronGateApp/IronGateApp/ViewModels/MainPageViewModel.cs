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
            Temperature = Int32.Parse(climateBasement.Channel.BasementTemp)
        });

        Climate climateGroundFloor = await _climateService.GetGroundFloorClimateAsync();
        tmpData.Add(new()
        {
            Floor = "Ground floor",
            Temperature = Int32.Parse(climateGroundFloor.Channel.GroundFloorTemp)
        });

        Climate climateFirstFloor = await _climateService.GetFirstFloorClimateAsync();
        tmpData.Add(new()
        {
            Floor = "First floor",
            Temperature = Int32.Parse(climateFirstFloor.Channel.FirstFloorTemp)
        });

        return tmpData;
    }
}