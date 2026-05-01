using Microsoft.Extensions.Logging;
using SmsTestEditor.Desktop.ViewModels.Abstractions;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SmsTestEditor.Desktop.ViewModels
{
    class MainViewModel : IMainViewModel
    {
        private readonly ILogger _logger;

        public MainViewModel(ILogger<MainViewModel> logger)
        {
            _logger = logger;
        }





        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
