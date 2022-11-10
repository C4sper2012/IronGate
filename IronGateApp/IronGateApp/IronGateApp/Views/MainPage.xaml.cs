using IronGateApp.ViewModels;

namespace IronGateApp.Views
{
	public partial class MainPage : ContentPage
	{
		ClimateViewModel _climateViewModel;
		public MainPage(ClimateViewModel climateViewModel)
		{
			InitializeComponent();
			_climateViewModel = climateViewModel;
		}

		private void ContentPage_Loaded(object sender, EventArgs e)
		{
			_climateViewModel.Climate = 
		}
	}
}