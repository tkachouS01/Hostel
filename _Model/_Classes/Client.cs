using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace HostelProject._Model._Classes
{
    public class Client : Human
    {
        private string _passportNumber;

        public Client(int id, string firstName, string lastName, string middleName, DateTime dateOfBirth, string passportNumber) : base(id, firstName, lastName, middleName, dateOfBirth)
        {
            _passportNumber = Regex.IsMatch(passportNumber, @"^[A-Z]{2}\d{7}$", RegexOptions.IgnoreCase) ? passportNumber : throw new Exception("Не соответствует формату AB1234567!");
        }
        public string PassportNumber { get { return _passportNumber; } }
        public Dictionary<string, Tuple<string, object>> Characteristix
        {
            get
            {
                return new Dictionary<string, Tuple<string, object>>
                {
                    ["Id"] = new Tuple<string, object>("Id", Id),
                    ["FirstName"] = new Tuple<string, object>("Имя", FirstName),
                    ["LastName"] = new Tuple<string, object>("Фамилия", LastName),
                    ["MiddleName"] = new Tuple<string, object>("Отчество", MiddleName),
                    ["DateOfBirth"] = new Tuple<string, object>("Дата рождения", DateOfBirth.ToShortDateString()),
                    ["PassportNumber"] = new Tuple<string, object>("Номер паспорта", PassportNumber)
                };
            }
        }
        public override string ToString()
        {
            return $"{ new string('~', 70)}\n" + $" Клиент {Id}\n" + $"{ new string('~', 70)}\n" + $" ФИО: {FullName}\n" + $" Дата рождения: {DateOfBirth.ToShortDateString()}\n" + $" Номер паспорта: {PassportNumber}".ToString();
        }
    }
}