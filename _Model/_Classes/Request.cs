using System;
using System.Collections.Generic;
namespace HostelProject._Model._Classes
{
    public class Request
    {
        private int _id;
        private int _adminID;
        private int _clientID;
        private int _roomID;
        private double _priseRoom;
        private DateTime _bookedDateStart;
        private DateTime _bookedDateEnd;
        private DateTime _requestDate;
        public Request(int id, int adminID, int clientID, int roomID, double priseRoom, DateTime bookedDateStart, DateTime bookedDateEnd, DateTime requestDate)
        {
            _id = id;
            _adminID = adminID;
            _clientID = clientID;
            RoomID = roomID;
            PriseRoom = priseRoom;
            BookedDateStart = bookedDateStart;
            BookedDateEnd = bookedDateEnd;
            _requestDate = requestDate;
        }
        public int Id { get { return _id; } }
        public int AdminID { get { return _adminID; } }
        public int ClientID { get { return _clientID; } }
        public int RoomID { get { return _roomID; } set { _roomID = value; } }
        public double PriseRoom { get { return _priseRoom; } set { _priseRoom = value; } }
        public DateTime BookedDateStart { get { return _bookedDateStart; } set { if(_bookedDateEnd!=null && value>=_bookedDateEnd) _bookedDateStart = value; } }
        public DateTime BookedDateEnd { get { return _bookedDateEnd; } set { if (_bookedDateStart < value) _bookedDateEnd = value; else throw new Exception("Неверная конечная дата!"); } }
        public DateTime RequestDate { get { return _requestDate; } }
        public Dictionary<string, Tuple<string, object>> Characteristix
        {
            get
            {
                return new Dictionary<string, Tuple<string, object>>
                {
                    ["Id"] = new Tuple<string, object>("Id заявки", Id),
                    ["AdminID"] = new Tuple<string, object>("Id администратора", AdminID),
                    ["ClientID"] = new Tuple<string, object>("Id клиента", ClientID),
                    ["RoomID"] = new Tuple<string, object>("Id комнаты", RoomID),
                    ["PriseRoom"] = new Tuple<string, object>("Стоимость проживания", PriseRoom),
                    ["BookedDateStart"] = new Tuple<string, object>("Начальная дата", BookedDateStart),
                    ["BookedDateEnd"] = new Tuple<string, object>("Конечная дата", BookedDateEnd),
                    ["RequestDate"] = new Tuple<string, object>("Дата заявки", RequestDate)
                };
            }
        }
        public override string ToString()
        {
            return $"{ new string('~', 70)}\n" + $" Заявка {Id}\n" + $"{ new string('~', 70)}\n" + $" Id администратора: {AdminID}\n" + $" Id клиента: {ClientID}\n" + $" Id комнаты: {RoomID}\n" + $" Стоимость: {PriseRoom}\n" + $" Забронированные даты: {BookedDateStart} - {BookedDateEnd}\n" + $" Дата подачи заявки: {RequestDate}".ToString();
        }
    }
}