using System.Linq;
using Document = DocumentFormat.OpenXml.Wordprocessing.Document;
using Table = DocumentFormat.OpenXml.Wordprocessing.Table;
using Row = DocumentFormat.OpenXml.Spreadsheet.Row;
using Cell = DocumentFormat.OpenXml.Spreadsheet.Cell;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using Run = DocumentFormat.OpenXml.Spreadsheet.Run;
using System.Windows;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace WpfApp3
{
    class ExportToWord
    {

        public void SaveToWord()
        {
            try
            {
                string excelFilePath = "Reports/Report.xlsx";
                string wordOutputPath = "Reports/Report.docx";
                using (SpreadsheetDocument spreadsheetDoc = SpreadsheetDocument.Open(excelFilePath, false))
                {
                    WorkbookPart workbookPart = spreadsheetDoc.WorkbookPart;
                    WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                    SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(wordOutputPath, WordprocessingDocumentType.Document))
                    {
                        MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                        mainPart.Document = new Document();

                        Body body = new Body();
                        mainPart.Document.Append(body);

                        Table table = new Table();

                        foreach (Row excelRow in sheetData.Elements<Row>())
                        {
                            TableRow tableRow = new TableRow();

                            foreach (Cell excelCell in excelRow.Elements<Cell>())
                            {
                                TableCell tableCell = new TableCell();
                                tableCell.Append(new Paragraph(new Run(excelCell.CellValue.Text)));
                                tableRow.Append(tableCell);
                            }

                            table.Append(tableRow);
                        }

                        body.Append(table);
                        wordDoc.Save();
                        MessageBox.Show("Файл успешно сохранён", "Успех", MessageBoxButton.OK);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить файл", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
