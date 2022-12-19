using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using Microsoft.EntityFrameworkCore;
using WpfApp3.Reports;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        SqlLiteDbContext db = new SqlLiteDbContext();

        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;

            
        }

        // при загрузке окна
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // гарантируем, что база данных создана
            db.Database.EnsureCreated();
            // загружаем данные из БД
            db.Employee.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Employee.Local.ToObservableCollection();
            

            if (!Directory.Exists("Reports"))
            {
                Directory.CreateDirectory("Reports");
            }
        }

        // добавление
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow EmployeeWindow = new EmployeeWindow(new Employee());
            if (EmployeeWindow.ShowDialog() == true)
            {
                Employee Employee = EmployeeWindow.Employee;
                db.Employee.Add(Employee);
                db.SaveChanges();
                DataContext = db.Employee.Local.ToObservableCollection();
            }
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Employee? employee = employeeList.SelectedItem as Employee;
            // если ни одного объекта не выделено, выходим
            if (employee is null) return;

            EmployeeWindow EmployeeWindow = new EmployeeWindow(new Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                Id_pers = employee.Id_pers,
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                Date_of_Birth = employee.Date_of_Birth,
                Phone = employee.Phone,
                Department = employee.Department,
            });

            if (EmployeeWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                employee = db.Employee.Find(EmployeeWindow.Employee.Id);
                if (employee != null)
                {
                    employee.Name = EmployeeWindow.Employee.Name;
                    employee.Id_pers = EmployeeWindow.Employee.Id_pers;
                    employee.Surname = EmployeeWindow.Employee.Surname;
                    employee.Patronymic = EmployeeWindow.Employee.Patronymic;
                    employee.Date_of_Birth = EmployeeWindow.Employee.Date_of_Birth;
                    employee.Phone = EmployeeWindow.Employee.Phone;
                    employee.Department = EmployeeWindow.Employee.Department;

                    db.SaveChanges();
                    employeeList.Items.Refresh();
                }
            }
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Employee? employee = employeeList.SelectedItem as Employee;
            // если ни одного объекта не выделено, выходим
            if (employee is null) return;
            db.Employee.Remove(employee);
            db.SaveChanges();
        }
        //Подробнее
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Employee? employee = employeeList.SelectedItem as Employee;
            // если ни одного объекта не выделено, выходим
            if (employee is null) return;

            InfoWindow InfoWindow = new InfoWindow(employee);
            if (InfoWindow.ShowDialog() == true)
            {
                employee = db.Employee.Find(InfoWindow.Employee.Id);
                if (employee != null)
                {
                    employeeList.Items.Refresh();
                }
            }
        }

        private void Excel_Click(object sender, RoutedEventArgs e)
        {
            SaveExcel save = new SaveExcel(db.Employee);
        }

        private void JSON_Click(object sender, RoutedEventArgs e)
        {
            SaveJSON save = new SaveJSON(db.Employee);
        }

        private void Search_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var curentEmployee = db.Employee.ToList();
            curentEmployee = curentEmployee.Where(p => p.Id_pers.ToString().ToLower().Contains(Search.Text.ToLower())
            || string.Join(" ", p.Surname, p.Name, p.Patronymic).ToLower().Contains(Search.Text.ToLower())
            || p.Phone.ToLower().Contains(Search.Text.ToLower())
            || p.Date_of_Birth.ToLower().Contains(Search.Text.ToLower())
            || p.Department.ToLower().Contains(Search.Text.ToLower())).ToList();
            DataContext = curentEmployee;
            employeeList.Items.Refresh();
        }
    }
}
