using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using POC_AvaloniaMauiApp01.ViewModels;
using ZXing.Net.Maui;

namespace POC_AvaloniaMauiApp01.Maui;

public partial class ScannerPreviewView : ContentView
{
    public ScannerPreviewView()
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
            //Avalonia.Threading.Dispatcher.UIThread.Invoke(() =>
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var vm = (QRCodeViewModel)BindingContext!;
                
                // Update BarcodeGeneratorView
                vm.ScannedQrCode = first.Value;
                vm.ScannedQrCodeFormat = first.Format;
                                
                // Update Label
                vm.ScannedQrCodeInfo = $"Barcodes: {first.Format} -> {first.Value}";
            });
        }
        
    }
}


public class BoolToCameraConverter : IValueConverter
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