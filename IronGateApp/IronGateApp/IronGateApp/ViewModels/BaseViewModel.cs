using CommunityToolkit.Mvvm.ComponentModel;

namespace IronGateApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool _isRefreshing;
    }
}
