using Microsoft.Win32;
using System.Globalization;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using DocumentFormat.OpenXml.Drawing;

namespace WpfApp3
{
    public partial class EmployeeWindow : Window
    {
        public Employee Employee { get; private set; }
        public EmployeeWindow(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
            DataContext = Employee;
            fieldSurname.Focus();
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            int test;
            bool isError = string.IsNullOrEmpty(Employee.Surname)
                || string.IsNullOrEmpty(Employee.Name)
                || string.IsNullOrEmpty(Employee.Patronymic)
                || string.IsNullOrEmpty(Employee.Gender)
                || string.IsNullOrEmpty(Employee.Date_of_Birth.ToString())
                || string.IsNullOrEmpty(Employee.Age.ToString())
                || string.IsNullOrEmpty(Employee.Citizenship)
                || string.IsNullOrEmpty(Employee.PlaceOfResidence)
                || string.IsNullOrEmpty(Employee.GraduatedFromGrades)
                || string.IsNullOrEmpty(Employee.FinishedOnly)
                || string.IsNullOrEmpty(Employee.AverageScoreOfCertificate.ToString())
                || string.IsNullOrEmpty(Employee.Snils) 
                || Employee.Snils.Length != 8
                || !int.TryParse(Employee.Snils, out test)
                || string.IsNullOrEmpty(Employee.DisabilityCertificate)
                || string.IsNullOrEmpty(Employee.Orphan)
                || string.IsNullOrEmpty(Employee.Speciality)
                || string.IsNullOrEmpty(Employee.Certificate)
                || string.IsNullOrEmpty(Employee.Money)
                || string.IsNullOrEmpty(Employee.Enrollment)
                || string.IsNullOrEmpty(Employee.YearOfAdmission.ToString())
                ;
            if (!isError) 
            {
                DialogResult = true; 
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы PDF (*.pdf)|*.pdf|Все файлы (*.*)|*.*";
            openFileDialog.InitialDirectory = @"C:\";

            // Отображение диалога выбора файла и обработка результата
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                // Получение выбранного файла
                string selectedFileName = openFileDialog.FileName;
                DisabilityCertificateFile.Text = selectedFileName;
            }
        }

        private void Button_Click_Orphan(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы PDF (*.pdf)|*.pdf|Все файлы (*.*)|*.*";
            openFileDialog.InitialDirectory = @"C:\";

            // Отображение диалога выбора файла и обработка результата
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                // Получение выбранного файла
                string selectedFileName = openFileDialog.FileName;
                OrphanFile.Text = selectedFileName;
            }
        }

        private void RadioButton_Click_Gender(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.IsChecked == true)
            {
                Employee.Gender = (string)radioButton.Content;
            }
        }

        private void RadioButton_Click_GraduatedFromGrades(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.IsChecked == true)
            {
                Employee.GraduatedFromGrades = (string)radioButton.Content;
            }
        }

        private void RadioButton_Click_FinishedOnly(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Content.Equals("Нет"))
            {
                fieldFinishedOnly.IsEnabled = true;
                Employee.FinishedOnly = fieldFinishedOnly.Text;
            }else
            {
                Employee.FinishedOnly = "Да";
                fieldFinishedOnly.IsEnabled = false;
            }
        }

        private void RadioButton_Click_DisabilityCertificate(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Content.Equals("Да"))
            {
                DisabilityCertificateFile.IsEnabled = true;
                DCButton.IsEnabled = true;
                Employee.DisabilityCertificate = DisabilityCertificateFile.Text;
            }
            else
            {
                Employee.DisabilityCertificate = "Нет";
                DisabilityCertificateFile.IsEnabled = false;
                DCButton.IsEnabled = false;
            }
        }

        private void RadioButton_Click_Orphan(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Content.Equals("Да"))
            {
                OrphanFile.IsEnabled = true;
                OrphanButton.IsEnabled = true;
                Employee.Orphan = OrphanFile.Text;
            }
            else
            {
                Employee.Orphan = "Нет";
                OrphanFile.IsEnabled = false;
                OrphanButton.IsEnabled = false;
            }
        }

        private void RadioButton_Click_Certificate(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.IsChecked == true)
            {
                Employee.Certificate = radioButton.Content.ToString();
            }
        }

        private void RadioButton_Click_Money(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.IsChecked == true)
            {
                Employee.Money = (string)radioButton.Content;
            }
        }

        private void RadioButton_Click_Enrollment(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Content.Equals("Нет"))
            {
                Employee.Enrollment = "Не зачислен(а)";
            }
            else
            {
                Employee.Enrollment = "Зачислен(а)";
            }
        }

        private void fieldYearOfAdmission_TextChanged(object sender, TextChangedEventArgs e)
        {
            fieldYearOfAdmission.Text = DateTime.Now.Year.ToString();
            Employee.YearOfAdmission = DateTime.Now.Year;
        }

        private void fieldCitizenship_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock selectBlock = (TextBlock)fieldCitizenship.SelectedItem;
            Employee.Citizenship = selectBlock.Text;
        }

        private void fieldPlaceOfResidence_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fieldPlaceOfResidence.SelectedItem != null)
            {
                if (fieldPlaceOfResidence.SelectedItem is TextBlock textBlock)
                {
                    Employee.PlaceOfResidence = textBlock.Text;
                }
                else if (fieldPlaceOfResidence.SelectedItem is TextBox textBox)
                {
                    Employee.PlaceOfResidence = textBox.Text;
                }
                else if (fieldPlaceOfResidence.SelectedItem is StackPanel stackPanel)
                {
                    foreach (UIElement element in stackPanel.Children)
                    {
                        if (element is ComboBox innerComboBox && innerComboBox.SelectedItem is TextBlock innerTextBlock2)
                        {
                            Employee.PlaceOfResidence = "Костромская область " + innerTextBlock2.Text;
                            break;
                        }
                    }
                }
            }
        }

        private void fieldAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - Employee.Date_of_Birth.Year;
            if (Employee.Date_of_Birth > currentDate.AddYears(-age)) age--;
            fieldAge.Text = age.ToString();
            Employee.Age = age;
        }

        private void fieldSpeciality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock selectBlock = (TextBlock)fieldSpeciality.SelectedItem;
            Employee.Speciality = selectBlock.Text;
        }
    }
}
