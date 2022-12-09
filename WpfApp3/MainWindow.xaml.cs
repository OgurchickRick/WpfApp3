using System.Text.Json;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Collections;
using System.Collections.Generic;

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
            db.Users.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Users.Local.ToObservableCollection();
        }

        // добавление
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            UserWindow UserWindow = new UserWindow(new User());
            if (UserWindow.ShowDialog() == true)
            {
                User User = UserWindow.User;
                db.Users.Add(User);
                db.SaveChanges();
            }
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            User? user = usersList.SelectedItem as User;
            // если ни одного объекта не выделено, выходим
            if (user is null) return;

            UserWindow UserWindow = new UserWindow(new User
            {
                Id = user.Id,
                Name = user.Name,
                Id_pers = user.Id_pers,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                Date_of_Birth = user.Date_of_Birth,
                Phone = user.Phone,
                Department = user.Department,
            });

            if (UserWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                user = db.Users.Find(UserWindow.User.Id);
                if (user != null)
                {
                    user.Name = UserWindow.User.Name;
                    user.Id_pers = UserWindow.User.Id_pers;
                    user.Surname = UserWindow.User.Surname;
                    user.Patronymic = UserWindow.User.Patronymic;
                    user.Date_of_Birth = UserWindow.User.Date_of_Birth;
                    user.Phone = UserWindow.User.Phone;
                    user.Department = UserWindow.User.Department;

                    db.SaveChanges();
                    usersList.Items.Refresh();
                }
            }
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            User? user = usersList.SelectedItem as User;
            // если ни одного объекта не выделено, выходим
            if (user is null) return;
            db.Users.Remove(user);
            db.SaveChanges();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            User? user = usersList.SelectedItem as User;
            // если ни одного объекта не выделено, выходим
            if (user is null) return;

            InfoWindow InfoWindow = new InfoWindow(user);
            if (InfoWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                user = db.Users.Find(InfoWindow.User.Id);
                if (user != null)
                {
                    usersList.Items.Refresh();
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter file = File.CreateText("Employees.json");
            List <string> list = new List<string>();
            foreach (User u in db.Users) {
                string JSON = JsonSerializer.Serialize(u, typeof(User));
                file.WriteLine(JSON);
            }
            file.Close();
        }
    }
}
