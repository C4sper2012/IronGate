﻿using IronGateApp.Services;
using IronGateApp.DatabaseContext;
using IronGateApp.ViewModels;
using IronGateApp.Views;
using Syncfusion.Maui.Core.Hosting;

namespace IronGateApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            #region Scopes
            builder.Services.AddSingleton<ClimateDetailsPage>();
            builder.Services.AddSingleton<ClimatePage>();
            builder.Services.AddSingleton<ClimateService>();
            builder.Services.AddSingleton<ClimateViewModel>();
            builder.Services.AddTransient<ClimateDetailsViewModel>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<HomePageChartService>();

            builder.Services.AddSingleton<SettingsViewModel>();
            builder.Services.AddSingleton<SettingsPage>();

            builder.Services.AddTransient<IronGateContext>();
            #endregion

            return builder.Build();
        }
    }
}