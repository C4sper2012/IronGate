using CommunityToolkit.Mvvm.ComponentModel;

namespace IronGateApp.Models
{
    public partial class Setting : ObservableObject
    {
        #region Sensor detection

        [ObservableProperty]
        bool _shouldNotifyWaterLevel;

        [ObservableProperty]
        bool _shouldNotifyMotionDetected;

        #endregion

        #region Floor Climates

        [ObservableProperty]
        bool _firstFloorWindowIsEnabled;

        [ObservableProperty]
        bool _groundFloorWindowIsEnabled;

        [ObservableProperty]
        bool _basementWindowIsEnabled;

        #endregion

        #region Other options
        
        [ObservableProperty]
        bool _shouldCallPoliceOnMotionDetected;

        [ObservableProperty]
        bool _shouldLogMotionEntriesInApp;

        #endregion
    }
}