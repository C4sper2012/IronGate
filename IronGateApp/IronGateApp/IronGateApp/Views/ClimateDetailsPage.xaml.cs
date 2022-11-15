using IronGateApp.ViewModels;

namespace IronGateApp.Views
{
    public partial class ClimateDetailsPage : ContentPage
    {
        ClimateDetailsViewModel _climateDetailsViewModel;

        public ClimateDetailsPage(ClimateDetailsViewModel climateDetailsViewModel)
        {
            InitializeComponent();
            _climateDetailsViewModel = climateDetailsViewModel;
            BindingContext = climateDetailsViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _climateDetailsViewModel.AssignTemperatureAndHumidity();
        }
    }
}