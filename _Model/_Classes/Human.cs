using System;
namespace HostelProject._Model._Classes
{
    public class Human
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private DateTime _dateOfBirth;
        public Human(int id, string firstName, string lastName, string middleName, DateTime dateOfBirth)
        {
            _id = id;
            _firstName = ConvertToFormat(firstName);
            _lastName = ConvertToFormat(lastName);
            _middleName = ConvertToFormat(middleName);
            _dateOfBirth = dateOfBirth;
        }
        public int Id { get { return _id; } }
        public string FirstName { get { return _firstName; } set { _firstName = ConvertToFormat(value); } }
        public string LastName { get { return _lastName; } }
        public string MiddleName { get { return _middleName; } }
        public DateTime DateOfBirth { get { return _dateOfBirth; } }
        public string FullName { get { return _firstName + " " + _lastName + " " + _middleName; } }
        public static string ConvertToFormat(string str)
        {
            if (str.Length > 0) { str = str.ToLower(); return Char.ToUpper(str[0]) + str.Substring(1); }
            else throw new Exception("Длинна слова > 0!");
        }
    }
}