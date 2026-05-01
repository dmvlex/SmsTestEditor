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

    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
         => this.WindowState = WindowState.Minimized;
    private void CloseButton_Click(object sender, RoutedEventArgs e) => this.Close();
    private void TitleBar_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        => this.DragMove();
}