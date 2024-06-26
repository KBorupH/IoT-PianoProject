using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using Piano.UI.Models;
using Piano.UI.Views;
using Piano.UI.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Piano.Domain.Services;

namespace Piano.UI.ViewModels;

public class MainViewModel : ViewModelBase
{
    private IMusicService _musicService;

    private UserControl contentView;

    public UserControl ContentView
    {
        get { return contentView; }
        set
        {
            contentView = value;
        }
    }

    public MainViewModel(IMusicService musicService)
    {
        _musicService = musicService;

        contentView = new ManualPlayControl
        {
            DataContext = new ManualPlayControlModel(_musicService)
        };
    }

    public void SwitchUserControl(string userControlName)
    {
        switch (userControlName)
        {
            case "PlayNotesUserControl":
                
                break;
            case "PlaySheetsUserControl":
                break;
            case "RemotePlayUserControl":
                break;
            default:
                break;
        }
    }
}
