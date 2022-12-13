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
            //Типо валидация, очень страшная, но работает
            //Костыль на костыле, пока просто чтобы работало
            bool isValid = fieldSurname.Text.Length > 0
                & fieldName.Text.Length > 0
                & fieldPatronymic.Text.Length > 0
                & fieldBirth.Text.Length > 0
                & fieldPhone.Text.Length > 0
                & fieldDepartment.Text.Length > 0;
            if (isValid) 
            {
                DialogResult = true;
            }
        }
    }
}
