using System;
using System.ComponentModel;

public class Employee : IDataErrorInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Id_pers { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }

    public string Date_of_Birth { get; set; }

    public string Phone { get; set; }

    public string Department { get; set; }
    public string this[string columnName]
    {
        get
        {
            string error = String.Empty;
            switch (columnName)
            {
                case "Id_pers":
                    if (Id_pers == 0)
                    {
                        error = "Обязательное поле";
                    }
                    break;
                case "Surname":
                    if (Surname is null || Surname.Length == 0) 
                    {
                        error = "Обязательное поле";
                    }
                    break;
                case "Name":
                    if (Name is null || Name.Length == 0)
                    {
                        error = "Обязательное поле";
                    }
                    break;
                case "Patronymic":
                    if (Patronymic is null || Patronymic.Length == 0)
                    {
                        error = "Обязательное поле";
                    }
                    break;
                case "Date_of_Birth":
                    if (Date_of_Birth is null || Date_of_Birth.Length == 0)
                    {
                        error = "Обязательное поле";
                    }
                    break;
                case "Phone":
                    if (Phone is null || Phone.Length == 0)
                    {
                        error = "Обязательное поле";
                    }
                    break;
                case "Department":
                    if (Department is null || Department.Length == 0)
                    {
                        error = "Обязательное поле";
                    }
                    break;

            }
            return error;
        }
    }
    public string Error
    {
        get { throw new NotImplementedException(); }
    }

}