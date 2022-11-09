using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronGateApp.Models
{
    public partial class Settings : ObservableObject
    {
        [ObservableProperty]
        bool _shouldSendNotifications;
    }
}