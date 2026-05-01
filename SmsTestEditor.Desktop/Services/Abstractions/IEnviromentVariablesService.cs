using SmsTestEditor.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsTestEditor.Desktop.Services.Abstractions
{
    public interface IEnviromentVariablesService
    {
        List<EnviromentVariableModel> GetVariables(IEnumerable<string> variablesNames);
        void SetVariable(EnviromentVariableModel variable);
    }
}
