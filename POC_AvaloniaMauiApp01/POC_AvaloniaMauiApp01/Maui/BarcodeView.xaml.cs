using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using POC_AvaloniaMauiApp01.ViewModels;
using ReactiveUI;
using ReactiveUI.Maui;

namespace POC_AvaloniaMauiApp01.Maui;

public partial class BarcodeView : ReactiveContentView<QRCodeViewModel>
{
    public BarcodeView()
    {
        InitializeComponent();


        this.WhenActivated(d =>
        {
            // this.Bind(ViewModel, x => x.ScannedQrCode, x => x.GeneratorView.Value)
            //     .DisposeWith(d);
            // this.Bind(ViewModel, x => x.ScannedQrCodeFormat, x => x.GeneratorView.Format)
            //     .DisposeWith(d);

        });
    }
}