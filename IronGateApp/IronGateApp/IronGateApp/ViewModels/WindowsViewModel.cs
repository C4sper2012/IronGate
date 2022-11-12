using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IronGateApp.Services;

namespace IronGateApp.ViewModels
{
    public partial class WindowsViewModel : BaseViewModel
    {
        WindowService _windowService;
        public WindowsViewModel(WindowService windowService)
        {
            _windowService= windowService;
        }
        

        bool _firstFloorIsOpen;
        public bool FirsttFloorIsOpen 
        {
            get => _firstFloorIsOpen;
            set => _firstFloorIsOpen = value;
           
        }

        bool _groundFloorIsOpen;
        public bool GroundFloorIsOpen
        {
            get => _groundFloorIsOpen;
            set => _groundFloorIsOpen = value;
        }

        bool _basementIsOpen;
        public bool BasementIsOpen
        {
            get => _basementIsOpen;
            set => _basementIsOpen = value;
        }

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
            OnPropertyChanged();
        }


    }
}
