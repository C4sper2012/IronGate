using IronGateApp.ViewModels;

namespace IronGateApp.Views
{
    public partial class SensorPage : ContentPage
    {
        SensorViewModel _sensorViewModel;
        public SensorPage(SensorViewModel sensorViewModel)
        {
            InitializeComponent();
            _sensorViewModel = sensorViewModel;
            BindingContext = sensorViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
             _sensorViewModel.GetSensorCommand.Execute(null);
        }
    }
}