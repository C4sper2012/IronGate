using IronGateApp.ViewModels;

namespace IronGateApp.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage(MainPageViewModel mainPageViewModel)
		{
			InitializeComponent();
			BindingContext = mainPageViewModel;
		}
	}
}