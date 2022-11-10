using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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