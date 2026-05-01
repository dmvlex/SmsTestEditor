using CommunityToolkit.Mvvm.Input;
using SmsTestEditor.Desktop.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SmsTestEditor.Desktop.ViewModels.Abstractions
{
    public interface IMainViewModel : INotifyPropertyChanged
    {
        ObservableCollection<EnviromentVariableModel> Variables { get; set; }
        IAsyncRelayCommand SaveAllValuesCommand { get; }
    }
}
