using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmsTestEditor.Desktop.Extensions;
using SmsTestEditor.Desktop.Models;
using SmsTestEditor.Desktop.Services.Abstractions;
using SmsTestEditor.Desktop.ViewModels.Abstractions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SmsTestEditor.Desktop.ViewModels
{
    class MainViewModel : IMainViewModel
    {
        private readonly ILogger _logger;
        private readonly IEnviromentVariablesService _enviromentVariablesService;
        private readonly IConfiguration _configuration;

        private ObservableCollection<EnviromentVariableModel> _variables;

        public ObservableCollection<EnviromentVariableModel> Variables
        {
            get => _variables;
            set
            {
                if (value != _variables)
                {
                    _variables = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand SaveVariableCommand { get; }

        public MainViewModel(
            ILogger<MainViewModel> logger,
            IEnviromentVariablesService enviromentVariablesService,
            IConfiguration configuration)
        {
            _logger = logger;
            _enviromentVariablesService = enviromentVariablesService;
            _configuration = configuration;

            LoadVariables();
        }

        private void LoadVariables()
        {
            var variablesNames = _configuration.GetRequiredSection("AllowedEnviromentVariables")
                                               .Get<string[]>() ?? [];

            Variables = _enviromentVariablesService.GetVariables(variablesNames)
                                                   .ToObservable();
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
