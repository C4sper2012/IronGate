using IronGateApp.Services;
using IronGateApp.ViewModels;

namespace IronGateApp.Views
{
    public partial class ClimatePage : ContentPage
    {
        private readonly ClimateViewModel _climateViewModel;
        private readonly ClimateService _climateService;
        public ClimatePage(ClimateViewModel climateViewModel, ClimateService climateService)
        {
            InitializeComponent();
            _climateViewModel = climateViewModel;
            _climateService = climateService;
            BindingContext = _climateViewModel;
        }
    }
}