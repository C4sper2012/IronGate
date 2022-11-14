using IronGateApp.ViewModels;

namespace IronGateApp.Views
{
	public partial class MainPage : ContentPage
	{
		private readonly MainPageViewModel _mainPageViewModel;
		public MainPage(MainPageViewModel mainPageViewModel)
		{
			InitializeComponent();
			_mainPageViewModel = mainPageViewModel;
			BindingContext = mainPageViewModel;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await _mainPageViewModel.GetChartData();
			_mainPageViewModel.WaterLevel = await _mainPageViewModel.GetSensorDataAsync();
		}
	}
}