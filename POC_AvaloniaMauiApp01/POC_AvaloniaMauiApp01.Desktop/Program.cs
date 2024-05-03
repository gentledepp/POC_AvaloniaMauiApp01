using System;
using Avalonia;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;

namespace POC_AvaloniaMauiApp01.Desktop;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>(() =>
            {
                var services = new ServiceCollection();
                var app = new App();
                app.SetServices(services);
                
                // pre register any platform related services
                PreRegisterServices(services);
                // register the netstandard services
                app.ConfigureServices(services);
                // allow platform-specific overrides
                PostRegisterServices(services);
                
                return app;
            })
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();

    public static void PreRegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IPlatformInfo, WindowsPlatformInfo>();
    }

    public static void PostRegisterServices(IServiceCollection services)
    {
        
    }
}