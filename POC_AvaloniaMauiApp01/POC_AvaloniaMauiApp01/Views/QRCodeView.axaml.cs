using System;
using System.Globalization;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Microsoft.Maui.Controls;
using POC_AvaloniaMauiApp01.ViewModels;
using ZXing.Net.Maui;

namespace POC_AvaloniaMauiApp01.Views;

public partial class QRCodeView: UserControl
{
    public QRCodeView()
    {
        InitializeComponent();

    }
    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == DataContextProperty)
        {
            QRCodeScannerHost.Content!.BindingContext = change.NewValue;
            BarcodeViewHost.Content!.BindingContext = change.NewValue;
        }
    }
}
