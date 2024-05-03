using System.Linq;
using Avalonia;
using Avalonia.Controls;
using POC_AvaloniaMauiApp01.ViewModels;
using ZXing.Net.Maui;

namespace POC_AvaloniaMauiApp01.Views;

public partial class QRCodeView_Windows: UserControl
{
    public QRCodeView_Windows()
    {
        InitializeComponent();

    }

    private void BarcodesDetected(object? sender, BarcodeDetectionEventArgs e)
    {
        var allResults = e.Results.Where(r => r?.Value != null).Select(r => r?.Value).ToArray();

        
        ((QRCodeViewModel)DataContext).ScannedQRCodes = string.Join("|", allResults);
    }
}