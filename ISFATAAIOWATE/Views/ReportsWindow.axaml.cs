using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ISFATAAIOWATE.Views;

public partial class ReportsWindow : Window
{
    public ReportsWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}