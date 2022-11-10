namespace IronGateApp.Views
{
    public partial class WindowsPage : ContentPage
    {
        public WindowsPage()
        {
            InitializeComponent();
        }

        private void FirstFloor_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            Shell.Current.DisplayAlert("Windows!", "This is First Floor window", "OK");
        }
        
        private void GroundFloor_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            Shell.Current.DisplayAlert("Windows!", "This is Ground Floor window", "OK");
        }

        private void Basement_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            Shell.Current.DisplayAlert("Windows!", "This is Basement window", "OK");
        }


    }
}