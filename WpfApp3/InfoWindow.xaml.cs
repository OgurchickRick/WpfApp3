using System.Windows;

namespace WpfApp3
{

    public partial class InfoWindow : Window
    {
        SqlLiteDbContext db = new SqlLiteDbContext();

         public Employee Employee { get; }
        public InfoWindow(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
            DataContext = Employee;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
