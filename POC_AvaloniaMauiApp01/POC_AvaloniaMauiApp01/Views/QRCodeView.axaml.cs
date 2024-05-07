using System;
using System.Globalization;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Microsoft.Maui.Controls;
using POC_AvaloniaMauiApp01.ViewModels;
using ReactiveUI.Maui;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

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
            // not necessary as the ReactiveContentView itslef sync BindingContext and ViewModel
            // var previewCV = QRCodePreviewHost.Content as ReactiveContentView<QRCodeViewModel>;
            // var generatorCV = QRCodeGeneratorHost.Content as ReactiveContentView<QRCodeViewModel>;
            //
            // previewCV.ViewModel = (QRCodeViewModel)change.NewValue;
            // generatorCV.ViewModel = (QRCodeViewModel)change.NewValue;
            
            QRCodePreviewHost.Content!.BindingContext = change.NewValue;
            QRCodeGeneratorHost.Content!.BindingContext = change.NewValue;
        }
    }
}
