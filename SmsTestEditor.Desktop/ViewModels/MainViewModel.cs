using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmsTestEditor.Desktop.Extensions;
using SmsTestEditor.Desktop.Models;
using SmsTestEditor.Desktop.Services.Abstractions;
using SmsTestEditor.Desktop.ViewModels.Abstractions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Media;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace SmsTestEditor.Desktop.ViewModels
{
    class MainViewModel : IMainViewModel
    {
        private readonly ILogger _logger;
        private readonly IEnviromentVariablesService _enviromentVariablesService;
        private readonly IConfiguration _configuration;

        private bool _isSaving = false;
        public bool IsSaving
        {
            get => _isSaving;
            set
            {
                if (value != _isSaving)
                {
                    _isSaving = value;
                    OnPropertyChanged();
                }
            }
        }

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
        public IAsyncRelayCommand SaveAllValuesCommand { get; }

        public MainViewModel(
            ILogger<MainViewModel> logger,
            IEnviromentVariablesService enviromentVariablesService,
            IConfiguration configuration)
        {
            _logger = logger;
            _enviromentVariablesService = enviromentVariablesService;
            _configuration = configuration;

            SaveAllValuesCommand = new AsyncRelayCommand(SaveAllValues,CanExecuteSaveAllValues);

            LoadVariables();
        }

        //a.kh: сохраняем только если меняли значение переменной
        private bool CanExecuteSaveAllValues()
            => Variables.Any(v => v.IsVariableValueChanged) && !IsSaving;

        private async Task SaveAllValues()
        {
            var changedVariables = Variables.Where(v => v.IsVariableValueChanged).ToList();

            if (!changedVariables.Any()) return;

            if (changedVariables.Any(v => string.IsNullOrWhiteSpace(v.Comment)))
            {
                MessageBox.Show("Заполните комметарии к измененным значениям!", "Внимание!");
                return;
            }

            IsSaving = true;

            await Task.Run(() =>
            {
                foreach (var variable in changedVariables)
                {
                    _enviromentVariablesService.SetVariable(variable);
                    _logger.LogInformation(
                        $"Переменная {variable.Name} изменена. Новое значение: {variable.Value}. Комментарий: {variable.Comment}");
                }
            });

            ClearChanged(changedVariables);

            IsSaving = false;
        }

        private void LoadVariables()
        {
            var variablesNames = _configuration.GetRequiredSection("AllowedEnviromentVariables")
                                               .Get<string[]>() ?? [];

            Variables = _enviromentVariablesService.GetVariables(variablesNames)
                                                   .ToObservable();
        }
        private void ClearChanged(IEnumerable<EnviromentVariableModel> variables)
        {
            foreach (var variable in variables)
            {
                variable.IsVariableValueChanged = false;
                variable.Comment = null;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
