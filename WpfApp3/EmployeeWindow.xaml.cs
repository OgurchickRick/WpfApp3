using System.Windows;

namespace WpfApp3
{
    public partial class EmployeeWindow : Window
    {
        public Employee Employee { get; private set; }
        public EmployeeWindow(Employee user)
        {
            InitializeComponent();
            Employee = user;
            DataContext = Employee;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
