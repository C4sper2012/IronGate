namespace IronGateApp.Views;

public partial class ClimateDetailsPage : ContentPage
{
	public ClimateDetailsPage(ClimateDetailsPage climateDetailsPage)
	{
		InitializeComponent();
		BindingContext= climateDetailsPage;
	}
}