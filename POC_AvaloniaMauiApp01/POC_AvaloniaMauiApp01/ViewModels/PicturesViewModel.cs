using System;

namespace POC_AvaloniaMauiApp01.ViewModels;
using System.IO;
using System.Linq;
using System.Reactive;
using Avalonia.Collections;
using Avalonia.Media.Imaging;
using Microsoft.Maui.Media;
using Microsoft.Maui.Storage;
using ReactiveUI;

public class PicturesViewModel : ViewModelBase
{
    public PicturesViewModel()
    {
        TakePictureCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            if (MediaPicker.IsCaptureSupported)
            {
                try
                {
                    var p = await MediaPicker.Default.CapturePhotoAsync();
                    if (p is null)
                    {
                        Pictures.Clear();
                        return;
                    }

                    using var imageStream = File.OpenRead(p.FullPath);
                    Pictures.Add(Bitmap.DecodeToWidth(imageStream, 150));
                }
                catch (OperationCanceledException okex)
                {
                    
                }
            }
        });
        PickPictureCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            if (MediaPicker.IsCaptureSupported)
            {
                try
                {
                    var p = await FilePicker.Default.PickMultipleAsync();
                    if (p is null || !p.Any())
                    {
                        Pictures.Clear();
                        return;
                    }

                    foreach (var pic in p)
                    {
                        using var imageStream = File.OpenRead(pic.FullPath);
                        var bmp = Bitmap.DecodeToWidth(imageStream, 150);
                        Pictures.Add(bmp);
                    }
                
                }
                catch (OperationCanceledException okex)
                {
                    
                }
            }
        });
    }
    

    public AvaloniaList<Bitmap> Pictures { get; set; } = new AvaloniaList<Bitmap>();

    public ReactiveCommand<Unit,Unit> TakePictureCommand { get; private set; }
    public ReactiveCommand<Unit,Unit> PickPictureCommand { get; private set; }
}