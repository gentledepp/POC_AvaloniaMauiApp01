using System.Reactive;
using ReactiveUI;
using ZXing.Net.Maui;

namespace POC_AvaloniaMauiApp01.ViewModels;

public class QRCodeViewModel : ViewModelBase
{
    private string _scannedQrCodeInfo;
    private string _scannedQrCode;
    private BarcodeFormat _scannedQrCodeFormat;
    private bool _useFrontCamera;
    private bool _isTorchOn;

    public QRCodeViewModel()
    {
        SwitchCameraCommand = ReactiveCommand.Create(() =>
        {
            UseFrontCamera = !UseFrontCamera;
        });
        ToggleTorchCommand = ReactiveCommand.Create(() =>
        {
            IsTorchOn = !IsTorchOn;
        });

        ScannedQrCodeInfo = "Nothing scanned yet - scan a QR CODE!";

        ScannedQrCode = "OPTIQ";
        ScannedQrCodeFormat = BarcodeFormat.QrCode;
    }

    public ReactiveCommand<Unit,Unit> SwitchCameraCommand { get; private set; }
    public ReactiveCommand<Unit,Unit> ToggleTorchCommand { get; private set; }
    
    
    public bool UseFrontCamera
    {
        get => _useFrontCamera;
        set => this.RaiseAndSetIfChanged(ref _useFrontCamera, value);
    }
    public bool IsTorchOn
    {
        get => _isTorchOn;
        set => this.RaiseAndSetIfChanged(ref _isTorchOn, value);
    }
    
    public string? ScannedQrCodeInfo
    {
        get => _scannedQrCodeInfo;
        set => this.RaiseAndSetIfChanged(ref _scannedQrCodeInfo, value);
    }
    
    public string? ScannedQrCode
    {
        get => _scannedQrCode;
        set => this.RaiseAndSetIfChanged(ref _scannedQrCode, value);
    }
    
    public BarcodeFormat ScannedQrCodeFormat
    {
        get => _scannedQrCodeFormat;
        set => this.RaiseAndSetIfChanged(ref _scannedQrCodeFormat, value);
    }
}