using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using PessoasApp.Services;
using SQLitePCL;

namespace PessoasApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        Batteries_V2.Init();

        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>();

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<IPersonRepository, PersonRepository>();
        builder.Services.AddSingleton<PersonService>();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}

