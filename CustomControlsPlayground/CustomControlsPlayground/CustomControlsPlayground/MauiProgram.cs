﻿using CustomControlsPlayground.VIewModels;
using Microsoft.Extensions.Logging;

namespace CustomControlsPlayground;

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
        
        builder.Services.ConfigureViews();
        builder.Services.ConfigureServices();
        builder.Services.ConfigureViewModels();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
    
    private static void ConfigureViews(this IServiceCollection services)
    {
        services.AddTransient<MainPage>();
    }
    
    private static void ConfigureViewModels(this IServiceCollection services)
    {
        services.AddTransient<MainPageViewModel>();
    }
    
    private static void ConfigureServices(this IServiceCollection services)
    {
        
    }
}