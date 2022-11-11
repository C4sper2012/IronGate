using IronGateApp.ViewModels;

namespace IronGateApp.Views;

public partial class ClimateDetailsPage : ContentPage
{
	public ClimateDetailsPage(ClimateDetailsViewModel climateDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = climateDetailsViewModel;
	}
}