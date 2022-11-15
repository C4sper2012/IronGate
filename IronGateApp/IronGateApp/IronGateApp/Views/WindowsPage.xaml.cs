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
            BindingContext = _windowsViewModel;
            MessagingCenter.Subscribe<WindowsViewModel, bool>(this, "WindowMessage",
            (sender, updatedSuccessfully) =>
            {
                if (updatedSuccessfully)
                    DisplayAlert("Success!", "Window successfully toggled", "OK");
                else
                    DisplayAlert("Failed", "Window toggle failed...", "Awe man...");
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _windowsViewModel.GetSwitchState();

            FirstSwitch.Toggled += OnSwitch_Toggled;
            GroundSwitch.Toggled += OnSwitch_Toggled;
            BaseSwitch.Toggled += OnSwitch_Toggled;
        }


        private void OnSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            _windowsViewModel.ToggleWindowsCommand.Execute(null);
        }
    }
}