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
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Сотрудники");

                    worksheet.Cells[1, 1].Value = "ID работника";
                    worksheet.Cells[1, 2].Value = "Фамилия";
                    worksheet.Cells[1, 3].Value = "Имя";
                    worksheet.Cells[1, 4].Value = "Отчество";
                    worksheet.Cells[1, 5].Value = "Дата рождения";
                    worksheet.Cells[1, 6].Value = "Телефон";
                    worksheet.Cells[1, 7].Value = "Отдел";
                    int count = 2;
                    foreach (Employee employee in data)
                    {
                        worksheet.Cells[count, 1].Value = employee.Id_pers;
                        worksheet.Cells[count, 2].Value = employee.Surname;
                        worksheet.Cells[count, 3].Value = employee.Name;
                        worksheet.Cells[count, 4].Value = employee.Patronymic;
                        worksheet.Cells[count, 5].Value = employee.Date_of_Birth;
                        worksheet.Cells[count, 6].Value = employee.Phone;
                        worksheet.Cells[count, 7].Value = employee.Department;

                        count += 1;
                    }

                    FileInfo fi = new FileInfo(@"Report.xlsx");
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
