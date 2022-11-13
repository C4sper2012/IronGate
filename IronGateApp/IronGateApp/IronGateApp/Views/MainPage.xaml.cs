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

		//protected override void OnAppearing()
		//{
		//	base.OnAppearing();
		//	_mainPageViewModel.GetChartDataCommand.Execute(this);
		//}
	}
}