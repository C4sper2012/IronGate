using IronGateApp.ViewModels;

namespace IronGateApp.Views
{
    public partial class WindowsPage : ContentPage
    {
        WindowsViewModel _windowsViewModel;

        public WindowsPage(WindowsViewModel windowsViewModel)
        {
            InitializeComponent();
            _windowsViewModel = windowsViewModel;
            BindingContext= _windowsViewModel;
        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    await _windowsViewModel.GetSwitchState();
        //}

        private void BaseSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            _windowsViewModel.ToggleWindowsCommand.Execute("0");
        }

        private void GroundSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            _windowsViewModel.ToggleWindowsCommand.Execute("1");
        }

        private void FirstSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            _windowsViewModel.ToggleWindowsCommand.Execute("2");
        }

        private async void ContentPage_Loaded(object sender, EventArgs e)
        {
            await _windowsViewModel.GetSwitchState();
        }
    }
}