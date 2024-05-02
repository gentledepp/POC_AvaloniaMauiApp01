using System.IO;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Collections;
using Avalonia.Media.Imaging;
using Microsoft.Maui.Media;
using Microsoft.Maui.Storage;
using ReactiveUI;

namespace POC_AvaloniaMauiApp01.ViewModels;

public class MainViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static

    public MainViewModel()
    {
        CurrentViewModel = new PicturesViewModel();

        NavigateToNextCommand = ReactiveCommand.CreateFromTask(() =>
        {
            if (_currentViewModel is PicturesViewModel)
                CurrentViewModel = new QRCodeViewModel();
            else
                CurrentViewModel = new PicturesViewModel();

            return Task.CompletedTask;
        });
    }

    public ReactiveCommand<Unit,Unit> NavigateToNextCommand { get; private set; }
    
    private ViewModelBase? _currentViewModel;

    public ViewModelBase? CurrentViewModel
    {
        get => _currentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
    }
}