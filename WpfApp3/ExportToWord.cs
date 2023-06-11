using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using Document = DocumentFormat.OpenXml.Wordprocessing.Document;
using Table = DocumentFormat.OpenXml.Wordprocessing.Table;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using Run = DocumentFormat.OpenXml.Spreadsheet.Run;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
using System.Windows;

namespace WpfApp3
{
    class ExportToWord
    {

        public void SaveToWord()
        {
            string filePath = "Reports/Report.docx"; // Путь к файлу Word

            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                // Получить данные из базы данных
                List<Employee> employees = GetEmployeesFromDatabase();

                // Создать таблицу в документе Word
                Table table = new Table();

                // Добавить заголовки столбцов
                TableRow headerRow = new TableRow();
                headerRow.Append(CreateTableCell("Фамилия"));
                headerRow.Append(CreateTableCell("Имя"));
                headerRow.Append(CreateTableCell("Отчество"));
                headerRow.Append(CreateTableCell("Пол"));
                headerRow.Append(CreateTableCell("Дата рождения"));
                headerRow.Append(CreateTableCell("Полных лет"));
                headerRow.Append(CreateTableCell("Гражданство"));
                headerRow.Append(CreateTableCell("Место проживания"));
                headerRow.Append(CreateTableCell("Закончил классов\""));
                headerRow.Append(CreateTableCell("Закончил только(9/11)"));
                headerRow.Append(CreateTableCell("Средний балл аттестата"));
                headerRow.Append(CreateTableCell("СНИЛС"));
                headerRow.Append(CreateTableCell("Наличие справки об инвалидности"));
                headerRow.Append(CreateTableCell("Наличие документа о сиротстве(опекунстве)"));
                headerRow.Append(CreateTableCell("Специальность"));
                headerRow.Append(CreateTableCell("Аттестат"));
                headerRow.Append(CreateTableCell("Бюджет/Договор об оказании платных образовательных услуг"));
                headerRow.Append(CreateTableCell("Зачислен"));
                headerRow.Append(CreateTableCell("Год поступления"));
                table.Append(headerRow);

                // Заполнить таблицу данными
                foreach (Employee employee in employees)
                {
                    TableRow dataRow = new TableRow();
                    dataRow.Append(CreateTableCell(employee.Surname));
                    dataRow.Append(CreateTableCell(employee.Name));
                    dataRow.Append(CreateTableCell(employee.Patronymic));
                    dataRow.Append(CreateTableCell(employee.Gender));
                    dataRow.Append(CreateTableCell(employee.Date_of_Birth.ToString("dd.MM.yyyy")));
                    dataRow.Append(CreateTableCell(employee.Age.ToString()));
                    dataRow.Append(CreateTableCell(employee.Citizenship));
                    dataRow.Append(CreateTableCell(employee.PlaceOfResidence));
                    dataRow.Append(CreateTableCell(employee.GraduatedFromGrades));
                    dataRow.Append(CreateTableCell(employee.FinishedOnly));
                    dataRow.Append(CreateTableCell(employee.AverageScoreOfCertificate.ToString()));
                    dataRow.Append(CreateTableCell(employee.Snils));
                    dataRow.Append(CreateTableCell(employee.DisabilityCertificate));
                    dataRow.Append(CreateTableCell(employee.Orphan));
                    dataRow.Append(CreateTableCell(employee.Speciality));
                    dataRow.Append(CreateTableCell(employee.Certificate));
                    dataRow.Append(CreateTableCell(employee.Money));
                    dataRow.Append(CreateTableCell(employee.Enrollment));
                    dataRow.Append(CreateTableCell(employee.YearOfAdmission.ToString()));
                    table.Append(dataRow);
                }

                body.Append(table);
            }

            MessageBox.Show("Файл успешно сохранён", "Успех", MessageBoxButton.OK);
        }

        private TableCell CreateTableCell(string text)
        {
            TableCell cell = new TableCell();
            cell.Append(new Paragraph(new Run(new Text(text))));
            return cell;
        }

        private List<Employee> GetEmployeesFromDatabase()
        {
            using (SqlLiteDbContext dbContext = new SqlLiteDbContext())
            {
                // Получить все экземпляры класса Employee из базы данных
                return dbContext.Employee.ToList();
            }
        }
    }
}
