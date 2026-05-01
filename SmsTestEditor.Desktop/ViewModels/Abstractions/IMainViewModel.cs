using SmsTestEditor.Desktop.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace SmsTestEditor.Desktop.ViewModels.Abstractions
{
    public interface IMainViewModel : INotifyPropertyChanged
    {
        ObservableCollection<EnviromentVariableModel> Variables { get; set; }
        ICommand SaveVariableCommand { get; }
    }
}
