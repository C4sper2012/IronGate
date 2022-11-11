using IronGateApp.Views;

namespace IronGateApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ClimateDetailsPage), typeof(ClimateDetailsPage));
            
        }
    }
}