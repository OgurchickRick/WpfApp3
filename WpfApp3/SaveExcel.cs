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
                    worksheet.Cells[1, 5].Style.Numberformat.Format = "dd.mm.yyyy";
                    worksheet.Cells[1, 6].Value = "Полных лет";
                    worksheet.Cells[1, 7].Value = "Гражданство";
                    worksheet.Cells[1, 8].Value = "Место проживания";
                    worksheet.Cells[1, 9].Value = "Закончил классов";
                    worksheet.Cells[1, 10].Value = "Закончил только(9/11)";
                    worksheet.Cells[1, 11].Value = "Средний балл аттестата";
                    worksheet.Cells[1, 12].Value = "СНИЛС";
                    worksheet.Cells[1, 13].Value = "Наличие справки об инвалидности";
                    worksheet.Cells[1, 14].Value = "Наличие документа о сиротстве(опекунстве)";
                    worksheet.Cells[1, 15].Value = "Специальность";
                    worksheet.Cells[1, 16].Value = "Аттестат";
                    worksheet.Cells[1, 17].Value = "Бюджет/Договор об оказании платных образовательных услуг";
                    worksheet.Cells[1, 18].Value = "Зачислен";
                    worksheet.Cells[1, 19].Value = "Год поступления";
                    int count = 2;
                    foreach (Employee employee in data)
                    {
                        worksheet.Cells[count, 1].Value = employee.Surname;
                        worksheet.Cells[count, 2].Value = employee.Name;
                        worksheet.Cells[count, 3].Value = employee.Patronymic;
                        worksheet.Cells[count, 4].Value = employee.Gender;
                        worksheet.Cells[count, 5].Value = employee.Date_of_Birth.ToString("dd.MM.yyyy");
                        worksheet.Cells[count, 6].Value = employee.Age;
                        worksheet.Cells[count, 7].Value = employee.Citizenship;
                        worksheet.Cells[count, 8].Value = employee.PlaceOfResidence;
                        worksheet.Cells[count, 9].Value = employee.GraduatedFromGrades;
                        worksheet.Cells[count, 10].Value = employee.FinishedOnly;
                        worksheet.Cells[count, 11].Value = employee.AverageScoreOfCertificate;
                        worksheet.Cells[count, 12].Value = employee.Snils;
                        worksheet.Cells[count, 13].Value = employee.DisabilityCertificate;
                        worksheet.Cells[count, 14].Value = employee.Orphan;
                        worksheet.Cells[count, 15].Value = employee.Speciality;
                        worksheet.Cells[count, 16].Value = employee.Certificate;
                        worksheet.Cells[count, 17].Value = employee.Money;
                        worksheet.Cells[count, 18].Value = employee.Enrollment;
                        worksheet.Cells[count, 19].Value = employee.YearOfAdmission;

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
