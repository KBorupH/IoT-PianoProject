using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Piano.UI.Views;

public partial class MainView : UserControl
{
    private ContentControl _content;

    public MainView()
    {
        InitializeComponent();
    }

    private void OnButtonClick(object? sender, RoutedEventArgs e)
    {
        _content.Content = (string)((Button)sender).Content switch
        {
            "Manual play" => new ManualPlayControl(),
            //"Sheets" => new UserControl2(),
            //"Remote" => new UserControl3(),
            _ => new ManualPlayControl()
        };
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        _content = this.FindControl<ContentControl>("content");
    }
}
