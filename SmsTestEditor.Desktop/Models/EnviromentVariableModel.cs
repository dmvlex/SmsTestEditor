using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SmsTestEditor.Desktop.Models
{
    class EnviromentVariableModel : INotifyPropertyChanged
    {
        private string _value;

        public string Name { get; set; } = string.Empty;
        public string Value
        {
            get => _value;
            set
            {
                if (value != _value)
                {
                    _value = value;
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
