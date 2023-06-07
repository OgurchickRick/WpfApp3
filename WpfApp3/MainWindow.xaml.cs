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
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                Gender = employee.Gender,
                Date_of_Birth = employee.Date_of_Birth,
                Age = employee.Age,
                FullYears = employee.FullYears,
                Citizenship = employee.Citizenship,
                PlaceOfResidence = employee.PlaceOfResidence,
                GraduatedFromGrades = employee.GraduatedFromGrades,
                FinishedOnly = employee.FinishedOnly,
                AverageScoreOfCertificate = employee.AverageScoreOfCertificate,
                Snils = employee.Snils,
                DisabilityCertificate = employee.DisabilityCertificate,
                Orphan = employee.Orphan,
                Speciality = employee.Speciality,
                Certificate = employee.Certificate,
                Money = employee.Money,
                Enrollment = employee.Enrollment,
                YearOfAdmission = employee.YearOfAdmission
            });

            if (EmployeeWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                employee = db.Employee.Find(EmployeeWindow.Employee.Id);
                if (employee != null)
                {
                    employee.Name = EmployeeWindow.Employee.Name;
                    employee.Surname = EmployeeWindow.Employee.Surname;
                    employee.Patronymic = EmployeeWindow.Employee.Patronymic;
                    employee.Gender = EmployeeWindow.Employee.Gender;
                    employee.Date_of_Birth = EmployeeWindow.Employee.Date_of_Birth;
                    employee.Age = EmployeeWindow.Employee.Age;
                    employee.FullYears = EmployeeWindow.Employee.FullYears;
                    employee.Citizenship = EmployeeWindow.Employee.Citizenship;
                    employee.PlaceOfResidence = EmployeeWindow.Employee.PlaceOfResidence;
                    employee.GraduatedFromGrades = EmployeeWindow.Employee.GraduatedFromGrades;
                    employee.FinishedOnly = EmployeeWindow.Employee.FinishedOnly;
                    employee.AverageScoreOfCertificate = EmployeeWindow.Employee.AverageScoreOfCertificate;
                    employee.Snils = EmployeeWindow.Employee.Snils;
                    employee.DisabilityCertificate = EmployeeWindow.Employee.DisabilityCertificate;
                    employee.Orphan = EmployeeWindow.Employee.Orphan;
                    employee.Speciality = EmployeeWindow.Employee.Speciality;
                    employee.Certificate = EmployeeWindow.Employee.Certificate;
                    employee.Money = EmployeeWindow.Employee.Money;
                    employee.Enrollment = EmployeeWindow.Employee.Enrollment;
                    employee.YearOfAdmission = EmployeeWindow.Employee.YearOfAdmission;

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

    }
}
