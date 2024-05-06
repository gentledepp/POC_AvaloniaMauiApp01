using System;
using System.Globalization;
using System.Linq;
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

    private  void BarcodesDetected(object? sender, BarcodeDetectionEventArgs e)
    {
        foreach (var barcode in e.Results)
            Console.WriteLine($"Barcodes: {barcode.Format} -> {barcode.Value}");
            
        var first = e.Results?.FirstOrDefault();
        if (first is not null)
        {
            Avalonia.Threading.Dispatcher.UIThread.Invoke(() =>
            {
                var vm = (QRCodeViewModel)DataContext!;
                
                // Update BarcodeGeneratorView
                vm.ScannedQrCode = first.Value;
                vm.ScannedQrCodeFormat = first.Format;
                                
                // Update Label
                vm.ScannedQrCodeInfo = $"Barcodes: {first.Format} -> {first.Value}";
            });
        }
        
    }
}

public class BoolToCameraConverter : Avalonia.Data.Converters.IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool b && b)
            return CameraLocation.Front;

        return CameraLocation.Rear;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}