using System;
using System.Collections.Generic;
using HostelProject._Model._Classes;

namespace HostelProject._Model
{
    internal class СreatingObjects
    {
        public static object CreatingAdministrator(Dictionary<string, object> objectFeatures)
        {
            return new Administrator(
                id: (int)objectFeatures["Id"],
                firstName: (string)objectFeatures["FirstName"],
                lastName: (string)objectFeatures["LastName"],
                middleName: (string)objectFeatures["MiddleName"],
                dateOfBirth: (DateTime)objectFeatures["DateOfBirth"],
                login: (string)objectFeatures["Login"],
                password: (string)objectFeatures["Password"]
                );
        }
        public static object CreatingWorker(Dictionary<string, object> objectFeatures)
        {
            return new Worker(
                id: (int)objectFeatures["Id"],
                firstName: (string)objectFeatures["FirstName"],
                lastName: (string)objectFeatures["LastName"],
                middleName: (string)objectFeatures["MiddleName"],
                dateOfBirth: (DateTime)objectFeatures["DateOfBirth"],
                positionAtWork: (string)objectFeatures["PositionAtWork"],
                workingDays: (int[])objectFeatures["WorkingDays"]
                );
        }
        public static object CreatingClient(Dictionary<string, object> objectFeatures)
        {
            return new Client(
                id: (int)objectFeatures["Id"],
                firstName: (string)objectFeatures["FirstName"],
                lastName: (string)objectFeatures["LastName"],
                middleName: (string)objectFeatures["MiddleName"],
                dateOfBirth: (DateTime)objectFeatures["DateOfBirth"],
                passportNumber: (string)objectFeatures["PassportNumber"]);
        }
        public static object CreatingRoom(Dictionary<string, object> objectFeatures)
        {
            return new Room(
                id: (int)objectFeatures["Id"],
                floor: (int)objectFeatures["Floor"],
                prise: (double)objectFeatures["Prise"],
                type: (string)objectFeatures["Type"],
                capacity: (int)objectFeatures["Capacity"],
                description: (string)objectFeatures["Description"]);
        }
        public static object CreatingRequest(Dictionary<string, object> objectFeatures)
        {
            return new Request(
                id: (int)objectFeatures["Id"],
                adminID: (int)objectFeatures["AdminID"],
                clientID: (int)objectFeatures["ClientID"],
                roomID: (int)objectFeatures["RoomID"],
                priseRoom: (double)objectFeatures["PriseRoom"],
                bookedDateStart: (DateTime)objectFeatures["BookedDateStart"],
                bookedDateEnd: (DateTime)objectFeatures["BookedDateEnd"],
                requestDate: (DateTime)objectFeatures["RequestDate"]);
        }
    }
}