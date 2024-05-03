using Foundation;
using UIKit;
using Avalonia;
using Avalonia.Controls;
using Avalonia.iOS;
using Avalonia.Maui;
using Avalonia.Media;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using POC_AvaloniaMauiApp01.Maui;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace POC_AvaloniaMauiApp01.iOS;

// The UIApplicationDelegate for the application. This class is responsible for launching the 
// User Interface of the application, as well as listening (and optionally responding) to 
// application events from iOS.
[Register("AppDelegate")]
#pragma warning disable CA1711 // Identifiers should not have incorrect suffix
public partial class AppDelegate : AvaloniaAppDelegate<App>
#pragma warning restore CA1711 // Identifiers should not have incorrect suffix
{
    protected override AppBuilder CreateAppBuilder()
    {
        return AppBuilder.Configure<App>(() =>
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
        }).UseiOS();
    }

    private void PreRegisterServices(ServiceCollection services)
    {
        services.AddSingleton<IPlatformInfo, iOSPlatformInfo>();
    }
    
    private void PostRegisterServices(ServiceCollection services)
    {
        
    }

    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder)
            .WithInterFont()
            .UseReactiveUI()
            // support MAUI controls
            .UseMaui<MauiApplication>(this, configure: mauiBuilder => 
                // Add ZXING QR Code Scanning
                mauiBuilder.UseBarcodeReader())
            // initialize the Maui.Essentials platform
            .AfterSetup(_ =>
            {
                var vc = Window.RootViewController;
                Microsoft.Maui.ApplicationModel.Platform.Init(() => vc);
            });
    }
}