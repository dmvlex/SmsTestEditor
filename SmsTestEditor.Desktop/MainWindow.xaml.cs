using SmsTestEditor.Desktop.ViewModels.Abstractions;
using System.Windows;

namespace SmsTestEditor.Desktop;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(IMainViewModel mainViewModel)
    {
        InitializeComponent();
        DataContext = mainViewModel;
    }
}