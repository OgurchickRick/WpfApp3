using Microsoft.Win32;
using System.Globalization;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            bool isError = string.IsNullOrEmpty(Employee.Surname)
                || string.IsNullOrEmpty(Employee.Name)
                || string.IsNullOrEmpty(Employee.Patronymic);
            if (!isError) 
            {
                DialogResult = true; 
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.DefaultExt = ".png"; // Default file extension
            dialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
                DisabilityCertificateFile.Text = File.ReadAllText(dialog.FileName);
            }
        }

        private void Button_Click_Orphan(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.DefaultExt = ".png"; // Default file extension
            dialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
                OrphanFile.Text = File.ReadAllText(dialog.FileName);
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
                Employee.Enrollment = "Не зачислен";
            }
            else
            {
                Employee.Enrollment = "Зачислен";
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
            ComboBox comboBox = (ComboBox)sender;
            string selectedValue = comboBox.SelectedItem.ToString();
            Employee.PlaceOfResidence = selectedValue;
        }

        private void fieldPORKostroma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender == fieldPORKostroma)
            {
                Employee.PlaceOfResidence = "Костромская область " + ((TextBlock)fieldPORKostroma.SelectedItem).Text;
            }
        }

        private void fieldSpeciality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock selectBlock = (TextBlock)fieldSpeciality.SelectedItem;
            Employee.Speciality = selectBlock.Text;
        }

        private void fieldAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            DateTime currentDate = DateTime.Now; 
            int age = currentDate.Year - Employee.Date_of_Birth.Year; 
            if (Employee.Date_of_Birth > currentDate.AddYears(-age)) age--;
            fieldAge.Text = age.ToString();
            Employee.Age = age;
        }
    }
}
