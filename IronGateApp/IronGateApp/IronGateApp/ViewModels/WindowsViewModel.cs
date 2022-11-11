using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IronGateApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronGateApp.ViewModels
{
    public partial class WindowsViewModel : BaseViewModel
    {
        WindowService _windowService;
        public WindowsViewModel(WindowService windowService)
        {
            _windowService= windowService;
        }

        [ObservableProperty]
        bool _firstFloorIsOpen;
        [ObservableProperty]
        bool _groundFloorIsOpen;
        [ObservableProperty]
        bool _basementIsOpen;

        [RelayCommand]
        async Task ToggleWindowsAsync(string index)
        {
            try
            {
                await _windowService.ToggleWindows(index);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task GetSwitchState()
        {
           var windowState =  await _windowService.GetFloorWindowState();
            _basementIsOpen = windowState.Item1;
            _groundFloorIsOpen = windowState.Item2;
            _firstFloorIsOpen = windowState.Item3;
        }


    }
}
