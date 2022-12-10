using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace WpfApp3
{
    internal class SaveJSON
    {
        private JsonSerializerOptions options;

        public SaveJSON(DbSet<Employee> data)
        {
            options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string JSON = JsonSerializer.Serialize(data, options);
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                FileName = "Employees",
                DefaultExt = ".json",
                Filter = "JSON file (.json)|*.json"
            };

            bool? result = saveDialog.ShowDialog();

            if (result == true)
            {
                using (StreamWriter sw = new StreamWriter(saveDialog.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.WriteLine(JSON);
                    sw.Close();
                }
            }
        }
    }
}
