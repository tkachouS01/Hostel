using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace HostelProject._Model
{
    public class WorkingWithAFile
    {
        private static string _fileName;

        public WorkingWithAFile(string fileName)
        {
            _fileName = fileName + ".txt";
        }
        private delegate object myDeleg(string objectFeatures);
        public static List<Exception> listExceptions = new List<Exception>();
        public List<object> ReadingFile()
        {
            if (!File.Exists(_fileName))
                File.Create(_fileName);
            List<object> allObjects = new List<object>();
            StreamReader sr = new StreamReader(_fileName, Encoding.UTF8);
            try
            {
                Dictionary<string, myDeleg> listFeatures = new Dictionary<string, myDeleg>
                {
                    ["Administrator"] = new myDeleg(ParsingAFileString.ParsingAdministrator),
                    ["Worker"] = new myDeleg(ParsingAFileString.ParsingWorker),
                    ["Client"] = new myDeleg(ParsingAFileString.ParsingClient),
                    ["Room"] = new myDeleg(ParsingAFileString.ParsingRoom),
                    ["Request"] = new myDeleg(ParsingAFileString.ParsingRequest)
                };
                string objectFeatures;
                int aa = 0;
                while (true)
                {
                    if ((objectFeatures = sr.ReadLine()) == null)
                        break;
                    aa++;
                    
                    try
                    {
                        string mask = @"^(.+): (.+)";
                        if (Regex.IsMatch(objectFeatures, mask))
                        {
                            Match match = Regex.Match(objectFeatures, mask);
                            if(match.Groups[1].Value=="Room")
                            { }
                            allObjects.Add(listFeatures[match.Groups[1].Value](match.Groups[2].Value));
                        }
                        else
                            throw new Exception("Неверная конструкция.\n Неисправность в строке: " + objectFeatures);
                    }
                    catch (Exception ex)
                    { listExceptions.Add(ex); continue; }
                }
            }
            catch (Exception ex)
            {
                if (sr != null)
                    sr.Close(); 
                throw new Exception(ex.Message); 
            }
            if (sr != null)
                sr.Close();
            return allObjects;
        }

        public static void WritingToFile(List<object> listObjects)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(_fileName, false, Encoding.UTF8);

                int num = listObjects.Count;
                for (int i = 0; i<num; i++)
                {
                    Type type = listObjects[i].GetType();
                    
                    PropertyInfo[] propertyInfo = type.GetProperties();
                    if (type.Name == "Administrator")
                        sw.WriteLine($"{type.Name}: Id={propertyInfo[IndexProperty(propertyInfo, "Id")].GetValue(listObjects[i])}; " +
                            $"FirstName={propertyInfo[IndexProperty(propertyInfo, "FirstName")].GetValue(listObjects[i])}; " +
                            $"LastName={propertyInfo[IndexProperty(propertyInfo, "LastName")].GetValue(listObjects[i])}; " +
                            $"MiddleName={propertyInfo[IndexProperty(propertyInfo, "MiddleName")].GetValue(listObjects[i])}; " +
                            $"DateOfBirth={((DateTime)propertyInfo[IndexProperty(propertyInfo, "DateOfBirth")].GetValue(listObjects[i])).ToShortDateString()}; " +
                            $"Login={propertyInfo[IndexProperty(propertyInfo, "Login")].GetValue(listObjects[i])}; " +
                            $"Password={propertyInfo[IndexProperty(propertyInfo, "Password")].GetValue(listObjects[i])};");
                    else if (type.Name == "Worker")
                        sw.WriteLine($"{type.Name}: Id={propertyInfo[IndexProperty(propertyInfo, "Id")].GetValue(listObjects[i])}; " +
                            $"FirstName={propertyInfo[IndexProperty(propertyInfo, "FirstName")].GetValue(listObjects[i])}; " +
                            $"LastName={propertyInfo[IndexProperty(propertyInfo, "LastName")].GetValue(listObjects[i])}; " +
                            $"MiddleName={propertyInfo[IndexProperty(propertyInfo, "MiddleName")].GetValue(listObjects[i])}; " +
                            $"DateOfBirth={((DateTime)propertyInfo[IndexProperty(propertyInfo, "DateOfBirth")].GetValue(listObjects[i])).ToShortDateString()}; " +
                            $"PositionAtWork={propertyInfo[IndexProperty(propertyInfo, "PositionAtWork")].GetValue(listObjects[i])}; " +
                            $"WorkingDays={string.Join("", (int[])propertyInfo[IndexProperty(propertyInfo, "WorkingDays")].GetValue(listObjects[i]))};");
                    else if (type.Name == "Client")
                        sw.WriteLine($"{type.Name}: Id={propertyInfo[IndexProperty(propertyInfo, "Id")].GetValue(listObjects[i])}; " +
                            $"FirstName={propertyInfo[IndexProperty(propertyInfo, "FirstName")].GetValue(listObjects[i])}; " +
                            $"LastName={propertyInfo[IndexProperty(propertyInfo, "LastName")].GetValue(listObjects[i])}; " +
                            $"MiddleName={propertyInfo[IndexProperty(propertyInfo, "MiddleName")].GetValue(listObjects[i])}; " +
                            $"DateOfBirth={((DateTime)propertyInfo[IndexProperty(propertyInfo, "DateOfBirth")].GetValue(listObjects[i])).ToShortDateString()}; " +
                            $"PassportNumber={propertyInfo[IndexProperty(propertyInfo, "PassportNumber")].GetValue(listObjects[i])};");
                    else if (type.Name == "Room")
                        sw.WriteLine($"{type.Name}: Id={propertyInfo[IndexProperty(propertyInfo, "Id")].GetValue(listObjects[i])}; " +
                            $"Floor={ propertyInfo[IndexProperty(propertyInfo, "Floor")].GetValue(listObjects[i])}; " +
                            $"Prise={propertyInfo[IndexProperty(propertyInfo, "Prise")].GetValue(listObjects[i])}; " +
                            $"Type={propertyInfo[IndexProperty(propertyInfo, "Type")].GetValue(listObjects[i])}; " +
                            $"Capacity={propertyInfo[IndexProperty(propertyInfo, "Capacity")].GetValue(listObjects[i])}; " +
                            $"Description={propertyInfo[IndexProperty(propertyInfo, "Description")].GetValue(listObjects[i])};");
                    else if (type.Name == "Request")
                        //(Id)=(.+); (AdminID)=(.+); (ClientID)=(.+); (RoomID)=(.+); (PriseRoom)=(.+); (BookedDate)=(.+)-(.+); (RequestDate)=(.+);
                        sw.WriteLine($"{type.Name}: Id={propertyInfo[IndexProperty(propertyInfo, "Id")].GetValue(listObjects[i])}; " +
                            $"AdminID={propertyInfo[IndexProperty(propertyInfo, "AdminID")].GetValue(listObjects[i])}; " +
                            $"ClientID={propertyInfo[IndexProperty(propertyInfo, "ClientID")].GetValue(listObjects[i])}; " +
                            $"RoomID={propertyInfo[IndexProperty(propertyInfo, "RoomID")].GetValue(listObjects[i])}; " +
                            $"PriseRoom={propertyInfo[IndexProperty(propertyInfo, "PriseRoom")].GetValue(listObjects[i])}; " +
                            $"BookedDateStart={propertyInfo[IndexProperty(propertyInfo, "BookedDateStart")].GetValue(listObjects[i])}; " +
                            $"BookedDateEnd={propertyInfo[IndexProperty(propertyInfo, "BookedDateEnd")].GetValue(listObjects[i])}; " +
                            $"RequestDate={propertyInfo[IndexProperty(propertyInfo, "RequestDate")].GetValue(listObjects[i])};");
                    //ToShortDateString()
                }
            }
            catch (Exception ex)
            {  }
            finally
            {
                if (sw != null)
                    sw.Close();
                
            }
        }
        static private int IndexProperty(PropertyInfo[] property, string name)
        {
            for(int i=0;i<property.Count();i++)
            {
                if (property[i].Name == name)
                    return i;
            }
            throw new Exception("Нет такого свойства!");
        }
    }
}