using SmsTestEditor.Desktop.Models;

namespace SmsTestEditor.Desktop.Services.Abstractions
{
    public interface IEnviromentVariablesService
    {
        List<EnviromentVariableModel> GetVariables(IEnumerable<string> variablesNames);
        void SetVariable(EnviromentVariableModel variable);
    }
}
