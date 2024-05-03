using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using POC_AvaloniaMauiApp01.ViewModels;
using POC_AvaloniaMauiApp01.Views;

namespace POC_AvaloniaMauiApp01;

public partial class App : Application
{
    private IServiceCollection _services;
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public void SetServices(IServiceCollection services) => _services = services;
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<MainViewModel>();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Register all the services needed for the application to run
        
        

        // Creates a ServiceProvider containing services from the provided IServiceCollection
        var provider = _services.BuildServiceProvider();
        var vm = provider.GetRequiredService<MainViewModel>();

        var viewLocator = new ViewLocator(provider);
        this.DataTemplates.Add(viewLocator);
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = vm
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = vm
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}