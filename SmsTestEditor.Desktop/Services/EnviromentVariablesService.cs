using Microsoft.Extensions.Logging;
using SmsTestEditor.Desktop.Models;
using SmsTestEditor.Desktop.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsTestEditor.Desktop.Services
{
    //a.kh: при выборе уровня перменных среды я колебался между machine и user.
    //В тз явно не указан необходимый уровень переменных среды, потому остановился на user, потому что 
    // он не требует прав администратора.
    public class EnviromentVariablesService : IEnviromentVariablesService
    {
        /// <summary>
        /// Получает список переменных среды пользователя по списку ключей
        /// </summary>
        /// <remarks>
        /// a.kh: Я искал встроенные методы для получения всех значений по ключам, но
        /// в BCL есть только возможность получить их все для пользователя, а потом уже по ним искать.
        /// И так, и так получается сложность метода линейная - потому оставил получение по одной.
        /// </remarks>
        /// <param name="variablesNames">Список названий переменных</param>
        /// <returns>Список моделей переменных с названием и значений. Если переменная не была найдена - ее значение будет null</returns>
        public List<EnviromentVariableModel> GetVariables(IEnumerable<string> variablesNames)
        {
            var variables = new List<EnviromentVariableModel>();

            foreach (var name in variablesNames)
            {
                var variableValue = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User)
                    ?? string.Empty; 
                variables.Add(new(name, variableValue));
            }

            return variables;
        }

        /// <summary>
        /// Сохраняет значение переменной среды.
        /// </summary>
        /// <remarks>Если value == null, то переменная среды удаляется</remarks>
        /// <param name="variables">Модель измененной переменной</param>
        public void SetVariable(EnviromentVariableModel variable)
        {
            ArgumentNullException.ThrowIfNull(variable);
            Environment.SetEnvironmentVariable(variable.Name, variable.Value, EnvironmentVariableTarget.User);
        }
    }
}
