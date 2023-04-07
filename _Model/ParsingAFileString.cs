using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HostelProject._Model
{
    public static class ParsingAFileString
    {
        private const string messageError = " Информация не соответствует маске. ";
        static string mask;
        static Match match;
        public static object ParsingAdministrator(string objectFeatures)
        {
            mask = @"^(Id)=(.+); (FirstName)=(.+); (LastName)=(.+); (MiddleName)=(.+); (DateOfBirth)=(.+); (Login)=(.+); (Password)=(.+);";

            if (Regex.IsMatch(objectFeatures, mask))
                match = Regex.Match(objectFeatures, mask);
            else
                throw new Exception("(Administrator)" + messageError);

            return СreatingObjects.CreatingAdministrator(new Dictionary<string, object>
            {
                [match.Groups[1].Value] = Convert.ToInt32(match.Groups[2].Value),
                [match.Groups[3].Value] = Convert.ToString(match.Groups[4].Value),
                [match.Groups[5].Value] = Convert.ToString(match.Groups[6].Value),
                [match.Groups[7].Value] = Convert.ToString(match.Groups[8].Value),
                [match.Groups[9].Value] = Convert.ToDateTime(match.Groups[10].Value),
                [match.Groups[11].Value] = Convert.ToString(match.Groups[12].Value),
                [match.Groups[13].Value] = Convert.ToString(match.Groups[14].Value)
            });
        }
        private static int[] StringToArr(string str)
        {
            int[] temp = new int[str.Length];
            for(int i=0;i<temp.Length;i++)
            {
                temp[i] = Convert.ToInt32(str[i].ToString());
            }
            return temp;
;        }
        public static object ParsingWorker(string objectFeatures)
        {
            mask = @"^(Id)=(.+); (FirstName)=(.+); (LastName)=(.+); (MiddleName)=(.+); (DateOfBirth)=(.+); (PositionAtWork)=(.+); (WorkingDays)=(.+);";

            if (Regex.IsMatch(objectFeatures, mask))
                match = Regex.Match(objectFeatures, mask);
            else
                throw new Exception("(Worker)" + messageError);
            return СreatingObjects.CreatingWorker(new Dictionary<string, object>
            {
                [match.Groups[1].Value] = Convert.ToInt32(match.Groups[2].Value),
                [match.Groups[3].Value] = Convert.ToString(match.Groups[4].Value),
                [match.Groups[5].Value] = Convert.ToString(match.Groups[6].Value),
                [match.Groups[7].Value] = Convert.ToString(match.Groups[8].Value),
                [match.Groups[9].Value] = Convert.ToDateTime(match.Groups[10].Value),
                [match.Groups[11].Value] = Convert.ToString(match.Groups[12].Value),
                [match.Groups[13].Value] = StringToArr(match.Groups[14].Value)
            });
        }

        public static object ParsingClient(string objectFeatures)
        {
            mask = @"^(Id)=(.+); (FirstName)=(.+); (LastName)=(.+); (MiddleName)=(.+); (DateOfBirth)=(.+); (PassportNumber)=(.+);";

            if (Regex.IsMatch(objectFeatures, mask))
                match = Regex.Match(objectFeatures, mask);
            else
                throw new Exception("(Client)" + messageError);

            return СreatingObjects.CreatingClient(new Dictionary<string, object>
            {
                [match.Groups[1].Value] = Convert.ToInt32(match.Groups[2].Value),
                [match.Groups[3].Value] = Convert.ToString(match.Groups[4].Value),
                [match.Groups[5].Value] = Convert.ToString(match.Groups[6].Value),
                [match.Groups[7].Value] = Convert.ToString(match.Groups[8].Value),
                [match.Groups[9].Value] = Convert.ToDateTime(match.Groups[10].Value),
                [match.Groups[11].Value] = Convert.ToString(match.Groups[12].Value)
            });
        }

        public static object ParsingRoom(string objectFeatures)
        {
            mask = @"^(Id)=(.+); (Floor)=(.+); (Prise)=(.+); (Type)=(.+); (Capacity)=(.+); (Description)=(.+);";

            if (Regex.IsMatch(objectFeatures, mask))
                match = Regex.Match(objectFeatures, mask);
            else
                throw new Exception("(Room)" + messageError);

            return СreatingObjects.CreatingRoom(new Dictionary<string, object>
            {
                [match.Groups[1].Value] = Convert.ToInt32(match.Groups[2].Value),
                [match.Groups[3].Value] = Convert.ToInt32(match.Groups[4].Value),
                [match.Groups[5].Value] = Convert.ToDouble(match.Groups[6].Value),
                [match.Groups[7].Value] = Convert.ToString(match.Groups[8].Value),
                [match.Groups[9].Value] = Convert.ToInt32(match.Groups[10].Value),
                [match.Groups[11].Value] = Convert.ToString(match.Groups[12].Value)
            });
        }

        public static object ParsingRequest(string objectFeatures)
        {
            mask = @"^(Id)=(.+); (AdminID)=(.+); (ClientID)=(.+); (RoomID)=(.+); (PriseRoom)=(.+); (BookedDateStart)=(.+); (BookedDateEnd)=(.+); (RequestDate)=(.+);";

            if (Regex.IsMatch(objectFeatures, mask))
                match = Regex.Match(objectFeatures, mask);
            else
                throw new Exception("(Request)" + messageError);

            return СreatingObjects.CreatingRequest(new Dictionary<string, object>
            {
                [match.Groups[1].Value] = Convert.ToInt32(match.Groups[2].Value),
                [match.Groups[3].Value] = Convert.ToInt32(match.Groups[4].Value),
                [match.Groups[5].Value] = Convert.ToInt32(match.Groups[6].Value),
                [match.Groups[7].Value] = Convert.ToInt32(match.Groups[8].Value),
                [match.Groups[9].Value] = Convert.ToDouble(match.Groups[10].Value),
                [match.Groups[11].Value] = Convert.ToDateTime(match.Groups[12].Value),
                [match.Groups[13].Value] = Convert.ToDateTime(match.Groups[14].Value),
                [match.Groups[15].Value] = Convert.ToDateTime(match.Groups[16].Value)
            });
        }
    }
}