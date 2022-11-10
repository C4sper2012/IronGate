using IronGateApp.ViewModels;

namespace IronGateApp.Views
{
    public partial class ClimatePage : ContentPage
    {
        private readonly ClimateViewModel _climateViewModel;

        public ClimatePage(ClimateViewModel climateViewModel)
        {
            InitializeComponent();
            _climateViewModel = climateViewModel;
            BindingContext = _climateViewModel;
        }
    }
}