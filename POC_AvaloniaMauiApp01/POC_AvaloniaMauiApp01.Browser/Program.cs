using System.Runtime.Versioning;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Browser;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using POC_AvaloniaMauiApp01;
using POC_AvaloniaMauiApp01.Browser;

[assembly: SupportedOSPlatform("browser")]

internal sealed partial class Program
{
    private static Task Main(string[] args) => BuildAvaloniaApp()
        .WithInterFont()
        .UseReactiveUI()
        .StartBrowserAppAsync("out");

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
        });
    
    
    public static void PreRegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IPlatformInfo, BrowserPlatformInfo>();
    }

    public static void PostRegisterServices(IServiceCollection services)
    {
        
    }
}