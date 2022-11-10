using Android.OS.Strictmode;
using IronGateApp.ViewModels;

namespace IronGateApp.Views
{
	public partial class MainPage : ContentPage
	{
		ClimateViewModel _climateViewModel;
		public MainPage(/*ClimateViewModel climateViewModel*/)
		{
			InitializeComponent();
			//_climateViewModel = climateViewModel;

		}

		//protected override void OnAppearing()
		//{

		//	base.OnAppearing();
		//	_climateViewModel.GetClimateCommand.Execute("");
		//}
	}
}