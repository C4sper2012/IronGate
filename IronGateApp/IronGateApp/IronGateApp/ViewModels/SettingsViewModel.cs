using CommunityToolkit.Mvvm.Input;
using IronGateApp.Models;

namespace IronGateApp.ViewModels
{
    public partial class SettingsViewModel : BaseViewModel
    {
        public Setting Setting { get; } = new();

        [RelayCommand]
        async Task SaveSettings()
        {
            try
            {
            }
            catch (Exception ex)
            {

            }
            finally
            {
            }
        }
    }
}