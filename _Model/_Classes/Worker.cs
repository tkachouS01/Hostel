using System;
using System.Collections.Generic;
namespace HostelProject._Model._Classes
{
    public class Worker : Human
    {
        private string _positionAtWork;
        private int[] _workingDays;
        public Worker(int id, string firstName, string lastName, string middleName, DateTime dateOfBirth, string positionAtWork, int[] workingDays) : base(id, firstName, lastName, middleName, dateOfBirth)
        {
            PositionAtWork = positionAtWork;
            WorkingDays = workingDays;
        }
        public string PositionAtWork { get { return _positionAtWork; } set { _positionAtWork = ConvertToFormat(value); } }
        public int[] WorkingDays
        {
            get { return _workingDays; }
            set
            {
                if (value.Length == 7)
                    for (int i = 0; i < 7; i++)
                    { if (value[i] != 0 && value[i] != 1) throw new Exception("Неверный формат данных!"); }
                else throw new Exception("Размер матрицы = 7!");
                _workingDays = value;
            }
        }
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
                    ["PositionAtWork"] = new Tuple<string, object>("Должность", PositionAtWork),
                    ["WorkingDays"] = new Tuple<string, object>("Рабочие дни", WorkingDaysConvert())
                };
            }
        }
        public string WorkingDaysConvert()
        {
            int num = 0;
            for (int i = 0; i < 7; i++)
            { if (_workingDays[i] == 1) num++; }
            string[] days = new string[num];
            int j = 0;
            for (int i = 0; i < 7; i++)
            {
                if (_workingDays[i] == 0) continue;
                switch (i+1)
                {
                    case 1: days[j] = "Понедельник"; break;
                    case 2: days[j] = "Вторник"; break;
                    case 3: days[j] = "Среда"; break;
                    case 4: days[j] = "Четверг"; break;
                    case 5: days[j] = "Пятница"; break;
                    case 6: days[j] = "Суббота"; break;
                    case 7: days[j] = "Воскресенье"; break;
                }
                j++;
            }
            return days.Length == 0 ? "Нет" : string.Join(", ", days);
        }
        public override string ToString()
        {
            return
                $"{ new string('~', 70)}\n" + $" Работник {Id}\n" + $"{ new string('~', 70)}\n" + $" ФИО: {FullName}\n" + $" Должность: { PositionAtWork}\n" + $" Дата рождения: {DateOfBirth.ToShortDateString()}\n" + $" Рабочие дни: {WorkingDaysConvert()}" .ToString();
        }
    }
}