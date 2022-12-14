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
                || string.IsNullOrEmpty(Employee.Date_of_Birth)
                || string.IsNullOrEmpty(Employee.Phone)
                || string.IsNullOrEmpty(Employee.Department);
            if (!isError) 
            {
                DialogResult = true; 
            }
        }
    }
}
