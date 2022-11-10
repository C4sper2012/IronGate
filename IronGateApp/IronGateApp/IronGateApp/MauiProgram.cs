using IronGateApp.ViewModels;
using IronGateApp.Views;

namespace IronGateApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ClimateDetailsPage>();
            builder.Services.AddSingleton<ClimatePage>();
            builder.Services.AddSingleton<ClimateViewModel>();
            builder.Services.AddTransient<ClimateDetailsViewModel>();

            builder.Services.AddSingleton<SettingsViewModel>();
            builder.Services.AddSingleton<SettingsPage>( );

            return builder.Build();
        }
    }
}