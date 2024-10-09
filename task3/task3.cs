using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApp3
{
	class task3
	{
		static void Main(string[] args)
		{
            

            if (args.Length != 3)
			{
				Console.WriteLine("Введите: <values.json> <tests.json> <report.json>");
				return;
			}

			string valuesPath = args[0];
            string testsPath = args[1];
            string reportPath = args[2];

            // Чтение данных из файлов
            var values = ReadJsonFile<Dictionary<string, object>>(valuesPath);
            var tests = ReadJsonFile<JToken>(testsPath);

            // Формирование отчета
            var report = CreateReport(tests, values);

            // Запись отчета в файл
            File.WriteAllText(reportPath, JsonConvert.SerializeObject(report, Formatting.Indented));
            Console.WriteLine($"Отчет выведен в файл: {reportPath}");
            Console.ReadKey();
            
        }

        static T ReadJsonFile<T>(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }

        static JToken CreateReport(JToken tests, Dictionary<string, object> values)
        {
            // Клонируем структуру tests для заполнения значениями
            var report = tests.DeepClone();

            FillReportValues(report, values);
            return report;
        }

        static void FillReportValues(JToken token, Dictionary<string, object> values)
        {
            if (token.Type == JTokenType.Object)
            {
                foreach (var property in token.Children<JProperty>())
                {
                    if (property.Name == "id" && property.Value is JToken idToken)
                    {
                        string id = idToken.ToString();
                        if (values.ContainsKey(id))
                        {
                            // Заполняем "value" на основе id
                            property.AddAfterSelf(new JProperty("value", values[id]));
                        }
                    }

                    FillReportValues(property.Value, values);
                }
            }
            else if (token.Type == JTokenType.Array)
            {
                foreach (var item in token.Children())
                {
                    FillReportValues(item, values);
                }
            }
           
        }
	}
}
