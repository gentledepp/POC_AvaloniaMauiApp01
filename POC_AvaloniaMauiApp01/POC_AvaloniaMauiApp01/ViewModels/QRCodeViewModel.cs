using System.Reactive;
using ReactiveUI;

namespace POC_AvaloniaMauiApp01.ViewModels;

public class QRCodeViewModel : ViewModelBase
{
    public string _scannedQRCodes;

    public QRCodeViewModel()
    {

        ScanQRCodeCommand = ReactiveCommand.CreateFromTask(async () => { });
    }

    public ReactiveCommand<Unit,Unit> ScanQRCodeCommand { get; private set; }
    
    public string? ScannedQRCodes
    {
        get => _scannedQRCodes;
        set => this.RaiseAndSetIfChanged(ref _scannedQRCodes, value);
    }
}