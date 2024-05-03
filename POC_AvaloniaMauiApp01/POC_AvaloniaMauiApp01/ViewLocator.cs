using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Microsoft.Extensions.DependencyInjection;
using POC_AvaloniaMauiApp01.ViewModels;

namespace POC_AvaloniaMauiApp01;

public class ViewLocator : IDataTemplate
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IPlatformInfo _platformSvc;

    public ViewLocator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _platformSvc = _serviceProvider.GetRequiredService<IPlatformInfo>();
    }
    
    public Control? Build(object? data)
    {
        if (data is null)
            return null;

        var name = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
        var type = Type.GetType(name);

        var platformSpecificName = $"{name}_{Enum.GetName(typeof(Platform), _platformSvc.Platform)}"; 
        var platformType = Type.GetType(platformSpecificName);

        // allow to return platformspecific views
        if (platformType != null)
            return (Control)Activator.CreateInstance(platformType)!;

        if (type != null)
            return (Control)Activator.CreateInstance(type)!;

        return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}