using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace SmsTestEditor.Desktop.Models
{
    public class EnviromentVariableModel : INotifyPropertyChanged
    {
        private string? _value;
        private string? _comment;
        private bool _isVariableValueChanged = false;

        public EnviromentVariableModel(string name, string value)
        {
            _value = value;
            Name = name;
        }

        public string Name { get; set; } = string.Empty;
        public bool IsVariableValueChanged
        {
            get => _isVariableValueChanged;
            set
            {
                if(value != _isVariableValueChanged)
                {
                    _isVariableValueChanged = value;
                    OnPropertyChanged();
                }
            }
        }
        public string? Value
        {
            get => _value;
            set
            {
                if (value != _value)
                {
                    _value = value;
                    IsVariableValueChanged = true;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Комментарий к изменению поля. Сохраняется в логи
        /// </summary>
        /// <remarks>a.kh: в тз явно не указано что делать с полем комментарий, но 
        /// исходя из того что каждое изменение значения пременной мы логгируем - я 
        /// предположил что это поле не нужно хранить, а просто записывать комментарий в логи
        /// при изменении значения переменной
        /// </remarks>
        public string? Comment
        {
            get => _comment;
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
