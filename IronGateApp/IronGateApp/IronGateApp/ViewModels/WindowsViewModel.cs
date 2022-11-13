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

        [ObservableProperty]
        bool _firstFloorIsOpen;

        [ObservableProperty]
        bool _groundFloorIsOpen;

        [ObservableProperty]
        bool _basementIsOpen;

        [RelayCommand]
        async Task ToggleWindowsAsync()
        {
            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet) { return; }
                var message = await _windowService.ToggleWindows(_firstFloorIsOpen, _groundFloorIsOpen, _basementIsOpen);
                MessagingCenter.Send(this, "WindowMessage", message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [RelayCommand]
        public async Task<Tuple<bool, bool, bool>> GetSwitchState()
        {
           
            try
            {
                var windowState = await _windowService.GetFloorWindowState();
                return windowState;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
