using SmsTestEditor.Desktop.Models;
using SmsTestEditor.Desktop.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsTestEditor.Desktop.Services
{
    public class EnviromentVariablesService : IEnviromentVariablesService
    {
        /// <summary>
        /// Получает список переменных среды пользователя по списку ключей
        /// </summary>
        /// <remarks>
        /// a.kh: Я искал встроенные методы для получения всех значений по ключам, но
        /// в BCL есть только возможность получить их все для пользователя, а потом уже по ним искать
        /// и так, и так получается сложность метода линейная - потому оставил получение по одной.
        /// </remarks>
        /// <param name="variablesNames">Список названий переменных</param>
        /// <returns>Список моделей переменных с названием и значений. Если переменная не была найдена - ее значение будет null</returns>
        public List<EnviromentVariableModel> GetVariables(IEnumerable<string> variablesNames)
        {
            var variables = new List<EnviromentVariableModel>();

            foreach (var name in variablesNames)
            {
                var variableValue = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User)
                    ?? string.Empty; //a.kh: ???
                variables.Add(new()
                {
                    Name = name,
                    Value = variableValue
                });
            }

            return variables;
        }
        
        /// <summary>
        /// Сохраняет значения для переданных переменных среды
        /// </summary>
        /// <remarks>
        /// Для удаления переменной необходимо выставить значение "null"
        /// </remarks>
        /// <param name="variables">Список переменных со значениями</param>
        public void SetVariables(IEnumerable<EnviromentVariableModel> variables)
        {
            ArgumentNullException.ThrowIfNull(variables);

            if (variables.Count() == 0) 
                return;
            
            foreach (var variable in variables)
                Environment.SetEnvironmentVariable(variable.Name, variable.Value, EnvironmentVariableTarget.User);
        }
    }
}
