using CommunityToolkit.Mvvm.ComponentModel;
using IronGateApp.Models;

namespace IronGateApp.ViewModels
{
    public partial class SettingsViewModel : BaseViewModel
    {
        public Setting Setting { get; } = new();

        #region Sensor detection

        [ObservableProperty]
        bool _shouldNotifyWaterLevel;

        [ObservableProperty]
        bool _shouldNotifyMotionDetected;

        #endregion

        #region Floor Climates

        [ObservableProperty]
        bool _shouldSendFirstFloorClimate;

        [ObservableProperty]
        bool _shouldSendGroundFloorClimate;

        [ObservableProperty]
        bool _shouldSendBasementClimate;

        #endregion

        #region Other options

        [ObservableProperty]
        bool _shouldCallPoliceOnMotionDetected;

        [ObservableProperty]
        bool _shouldLogMotionEntriesInApp;

        #endregion
    }
}