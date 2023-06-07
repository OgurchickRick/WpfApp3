using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp3.Reports
{
    internal class SaveExcel
    {
        public SaveExcel(DbSet<Employee> data)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Абитуриенты");
                    worksheet.Cells[1, 1].Value = "Фамилия";
                    worksheet.Cells[1, 2].Value = "Имя";
                    worksheet.Cells[1, 3].Value = "Отчество";
                    worksheet.Cells[1, 4].Value = "Пол";
                    worksheet.Cells[1, 5].Value = "Дата рождения";
                    worksheet.Cells[1, 6].Value = "Возраст";
                    worksheet.Cells[1, 7].Value = "Полных лет";
                    worksheet.Cells[1, 8].Value = "Гражданство";
                    worksheet.Cells[1, 9].Value = "Место проживания";
                    worksheet.Cells[1, 10].Value = "Закончил классов(9/11)";
                    worksheet.Cells[1, 11].Value = "Закончил только(9/11)";
                    worksheet.Cells[1, 12].Value = "Средний балл аттестата";
                    worksheet.Cells[1, 13].Value = "СНИЛС";
                    worksheet.Cells[1, 14].Value = "Наличие справки об инвалидности";
                    worksheet.Cells[1, 15].Value = "Наличие документа о сиротстве(опекунстве)";
                    worksheet.Cells[1, 16].Value = "Специальность";
                    worksheet.Cells[1, 17].Value = "Аттестат(оригинал/копия)";
                    worksheet.Cells[1, 18].Value = "Бюджет/Договор об оказании платных образовательных услуг";
                    worksheet.Cells[1, 19].Value = "Зачислен/Нет";
                    worksheet.Cells[1, 20].Value = "Год поступления";
                    int count = 2;
                    foreach (Employee employee in data)
                    {
                        worksheet.Cells[count, 1].Value = employee.Surname;
                        worksheet.Cells[count, 2].Value = employee.Name;
                        worksheet.Cells[count, 3].Value = employee.Patronymic;
                        worksheet.Cells[count, 4].Value = employee.Date_of_Birth;

                        count += 1;
                    }

                    FileInfo fi = new FileInfo("Reports/Report.xlsx");
                    excelPackage.SaveAs(fi);

                    MessageBox.Show("Файл успешно сохранён", "Успех", MessageBoxButton.OK);
                }

            }
            catch
            {
                MessageBox.Show("Не удалось сохранить файл", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
