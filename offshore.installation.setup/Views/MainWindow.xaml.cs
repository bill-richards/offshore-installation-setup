using System.Windows;
using offshore.installation.setup.ViewModels;

namespace offshore.installation.setup;

public partial class MainWindow : Window
{
    public MainWindow(IMainWindowModel model)
    {
        InitializeComponent();
        DataContext = model;
    }
}
