using IronGateApp.Models;

namespace IronGateApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public Setting Setting { get; } = new();
    }
}