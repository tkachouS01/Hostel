using System;
using System.Collections.Generic;
namespace HostelProject._Model._Classes
{
    public class Administrator : Human
    {
        private string _login;
        private string _password;

        public Administrator(int id, string firstName, string lastName, string middleName, DateTime dateOfBirth, string login, string password) : base(id, firstName, lastName, middleName, dateOfBirth)
        {
            _login = login;
            _password = password;
        }
        public string Login { get => _login; }
        public string Password { get => _password; }
        public Dictionary<string, Tuple<string, object>> Characteristix
        {
            get
            {
                return new Dictionary<string, Tuple<string, object>>
                {
                    ["Id"] = new Tuple<string, object>("Идентификатор", Id),
                    ["FirstName"] = new Tuple<string, object>("Имя", FirstName),
                    ["LastName"] = new Tuple<string, object>("Фамилия", LastName),
                    ["MiddleName"] = new Tuple<string, object>("Отчество", MiddleName),
                    ["DateOfBirth"] = new Tuple<string, object>("Дата рождения", DateOfBirth.ToShortDateString())
                };
            }
        }
        public override string ToString()
        {
            return $"{ new string('~', 70)}\n" + $" Администратор {Id}\n" + $"{ new string('~', 70)}\n" + $" ФИО: {FullName}\n" + $" Дата рождения: {DateOfBirth.ToShortDateString()}\n" .ToString();
        }
    }
}