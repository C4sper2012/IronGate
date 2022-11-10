using CommunityToolkit.Mvvm.ComponentModel;
using IronGateApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronGateApp.ViewModels
{
    [QueryProperty(nameof(Climate), "Climate")]
    public partial class ClimateViewModel : BaseViewModel
    {
        [ObservableProperty]
        Climate climate;

    }
}
