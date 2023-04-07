using System;
using System.Collections.Generic;
namespace HostelProject._Model._Classes
{
    public class Room
    {
        private int _id;
        private int _floor;
        private double _prise;
        private string _type;
        private int _capacity;
        private string _description;
        private List<Tuple<DateTime, DateTime>> listOfBookedDates;
        public static Dictionary<string, Tuple<string, object>> characteristix = new Dictionary<string, Tuple<string, object>>();
        public Room(int id, int floor, double prise, string type, int capacity, string description)
        {
            _id = id;
            _floor = floor;
            Prise = prise;
            Type = type;
            Capacity = capacity;
            Description = description;
        }
        public override string ToString()
        {
            return $"{ new string('~', 70)}\n" + $" Комната {_id}\n" + $"{ new string('~', 70)}\n" + $" Этаж: {_floor}\n" + $" Тип: {_type}\n" + $" Базовая стоимость: {_prise}\n" + $" Вместимость: {_capacity}\n" + $" Дополнительное описание: {_description}" .ToString();
        }
        public int Id { get { return _id; } }
        public int Floor { get { return _floor; } }
        public double Prise
        {
            get { return _prise; }
            set { if (value > 0) _prise = value; else throw new Exception("Стоимость > 0!"); }
        }
        public string Type { get { return _type; } set { _type = value; } }
        public int Capacity
        {
            get { return _capacity; }
            set { if (value > 0) _capacity = value; else throw new Exception("Вместимость > 0!"); }
        }
        public string Description { get { return _description; } set { _description = value; } }
        public Dictionary<string, Tuple<string, object>> Characteristix
        {
            get
            {
                return new Dictionary<string, Tuple<string, object>>
                {
                    ["Id"] = new Tuple<string, object>("Id комнаты", Id),
                    ["Floor"] = new Tuple<string, object>("Этаж", Floor),
                    ["Prise"] = new Tuple<string, object>("Стоимость за сутки", Prise),
                    ["Type"] = new Tuple<string, object>("Тип", Type),
                    ["Capacity"] = new Tuple<string, object>("Вместимость", Capacity),
                    ["Description"] = new Tuple<string, object>("Описание", Description)
                };
            }
        }
        public void AddToListOfBlokedDates(DateTime startDate, DateTime endDate) //добавление брони номера
        { listOfBookedDates.Add(new Tuple<DateTime, DateTime>(startDate, endDate)); }
        public bool CheckingTheDateInterval(DateTime startDate, DateTime endDate) //проверка брони номера
        {
            for (int i = 0; i < listOfBookedDates.Count; i++)
            { if (listOfBookedDates[i].Item1 <= endDate && listOfBookedDates[i].Item2 >= startDate) return true; }
            return false;
        }
    }
}