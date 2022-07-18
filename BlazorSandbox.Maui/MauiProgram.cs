using Microsoft.AspNetCore.Components.WebView.Maui;
using BlazorSandbox.Common.Data;
using Microsoft.EntityFrameworkCore;
using BlazorSandbox.Data;

namespace BlazorSandbox.Maui;

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
            });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        // Configure the database to use for the context
        // Enable database migrations to be generated in the BlazorSandbox.Data library project
        builder.Services.AddDbContext<SpaceOperaDbContext>(
            options => options
                .UseSqlite("Data Source=c:\\src\\spaceopera.db", options => options.MigrationsAssembly("BlazorSandbox.Data"))
        );

        builder.Services.AddSingleton<WeatherForecastService>();

        return builder
            .Build()
            // Update the database with the latest changes, when the application starts
            .MigrateDatabase();
    }
}
