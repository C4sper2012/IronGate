using IronGateApp.DatabaseContext;
using IronGateApp.ViewModels;

namespace IronGateApp.Views
{
    public partial class SettingsPage : ContentPage
    {
        SettingsViewModel _settingsViewModel;

        public SettingsPage(SettingsViewModel settingsViewModel)
        {
            InitializeComponent();

            _settingsViewModel = settingsViewModel;

            BindingContext = settingsViewModel;
        }

        private async void ContentPage_Loaded(object sender, EventArgs e)
        {
            _settingsViewModel.Setting = await _settingsViewModel.GetSettingsAsync();
        }
    }
}