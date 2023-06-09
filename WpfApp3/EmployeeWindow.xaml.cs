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
                || string.IsNullOrEmpty(Employee.Patronymic)
                || string.IsNullOrEmpty(Employee.Gender)
                || string.IsNullOrEmpty(Employee.Date_of_Birth)
                || int.IsPositive(Employee.Age)
                || string.IsNullOrEmpty(Employee.Citizenship)
                || string.IsNullOrEmpty(Employee.PlaceOfResidence)
                || string.IsNullOrEmpty(Employee.GraduatedFromGrades)
                || string.IsNullOrEmpty(Employee.FinishedOnly)
                || double.IsPositive(Employee.AverageScoreOfCertificate)
                || string.IsNullOrEmpty(Employee.Snils)
                || string.IsNullOrEmpty(Employee.DisabilityCertificate)
                || string.IsNullOrEmpty(Employee.Orphan)
                || string.IsNullOrEmpty(Employee.Speciality)
                || string.IsNullOrEmpty(Employee.Money)
                || int.IsPositive(Employee.YearOfAdmission);
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

    }
}
