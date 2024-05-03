using Android.App;
using Android.Content.PM;
using Android.OS;
using Avalonia;
using Avalonia.Android;
using Avalonia.Maui;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.ApplicationModel;
using POC_AvaloniaMauiApp01.Maui;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace POC_AvaloniaMauiApp01.Android;

[Activity(
    Label = "POC_AvaloniaMauiApp01.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity<App>
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
        }).UseAndroid();
    }

    private void PreRegisterServices(ServiceCollection services)
    {
        services.AddSingleton<IPlatformInfo, AndroidPlatformInfo>();

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
                mauiBuilder.UseBarcodeReader());
    }

    protected override void OnCreate(Bundle savedInstanceState)
    {
        // initialize the Maui.Essentials platform
        Microsoft.Maui.ApplicationModel.Platform.Init(this, savedInstanceState);
        base.OnCreate(savedInstanceState);
    }
}