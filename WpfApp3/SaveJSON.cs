using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows;

namespace WpfApp3
{
    internal class SaveJSON
    {
        private JsonSerializerOptions options;

        public SaveJSON(DbSet<Employee> data)
        {
            try
            {
                options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                string JSON = JsonSerializer.Serialize(data, options);
                StreamWriter file = File.CreateText("Reports/employee.json");
                file.WriteLine(JSON);
                file.Close();
                MessageBox.Show("Файл успешно сохранён", "Успех", MessageBoxButton.OK);
            }
            catch 
            {
                MessageBox.Show("Не удалось сохранить файл", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
