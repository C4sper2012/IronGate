using CommunityToolkit.Mvvm.Input;
using IronGateApp.DatabaseContext;
using IronGateApp.Models;

namespace IronGateApp.ViewModels
{
    public partial class SettingsViewModel : BaseViewModel
    {
        private readonly IronGateContext _ironGateContext;

        public Setting Setting { get; set; } = new();

        public SettingsViewModel(IronGateContext ironGateContext)
        {
            _ironGateContext = ironGateContext;
        }

        public async Task<Setting> GetSettingsAsync()
        {
            return await _ironGateContext.GetSettingsAsync();
        }

        [RelayCommand]
        async Task SaveSettings(Setting setting)
        {
            try
            {
                await _ironGateContext.SaveSettingsAsync(setting);
            }
            catch (Exception ex)
            {
                // TODO
            }

            await Shell.Current.DisplayAlert("Settings was saved!", "Your settings was saved", "Ok");
        }
    }
}