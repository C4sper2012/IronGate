using IronGateApp.ViewModels;

namespace IronGateApp.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage(SettingsViewModel settingsViewModel)
        {
            InitializeComponent();
            BindingContext = settingsViewModel;
        }
    }
}