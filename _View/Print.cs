using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static System.Console;
using ConsoleTables;

namespace HostelProject._Print
{
    public class Print
    {
        public static void BackgroundInformation(string[] info)
        {
            WriteLine();
            for (int i = 1; i<=info.Length; i++)
            {
                ForegroundColor = ConsoleColor.Green;
                Write($" [{i}]");
                ResetColor();
                Write($" - {info[i-1]}.\n");
            }
            Write("\n Введите запрос: ");
        }
        public static void OutputAsList(List<object> listObjects)
        {
            if (listObjects.Count == 1)
            {
                WriteLine();
                ForegroundColor = ConsoleColor.Blue;
                WriteLine(" Количество объектов: " + listObjects.Count);
                ResetColor();
                foreach (var valueObject in listObjects)
                    WriteLine(valueObject.ToString());
            }
            else
                OutputAsListTable(listObjects);
        }
        public static void OutputAsListTable(List<object> listObjects)
        {
            WriteLine();
            ForegroundColor = ConsoleColor.Blue;
            WriteLine(" Количество объектов: " + listObjects.Count);
            ResetColor();

            int numCharacteristix = 0;
            Type type = listObjects[0].GetType();
            PropertyInfo[] myPropertyInfo = type.GetProperties();
            for (int j = 0; j < myPropertyInfo.Length; j++)
            {
                if (myPropertyInfo[j].Name == "Characteristix")
                { numCharacteristix = j;break; }
            }  
            Dictionary<string, Tuple<string, object>> dictionary = ((Dictionary<string, Tuple<string, object>>)myPropertyInfo[numCharacteristix].GetValue(listObjects[0],null));
            string[] nameColumn = new string[dictionary.Count];
            for (int count1 = 0; count1 < nameColumn.Count(); count1++)
            {
                nameColumn[count1] = dictionary.ElementAt(count1).Value.Item1;
            }
            ConsoleTable table = new ConsoleTable(nameColumn);

            foreach (object valueObject in listObjects)
            {
                type = (valueObject).GetType();
                myPropertyInfo = type.GetProperties();

                for (int j = 0; j < myPropertyInfo.Length; j++)
                {
                    if (myPropertyInfo[j].Name == "Characteristix")
                    { numCharacteristix = j; break; }
                }
                
                Dictionary<string, Tuple<string, object>> dictionary1 =  (Dictionary<string, Tuple<string, object>>)myPropertyInfo[numCharacteristix].GetValue(valueObject);

                string[] tempRow = new string[nameColumn.Count()];
                for (int k = 0; k < tempRow.Count(); k++)
                {
                    tempRow[k] = Convert.ToString(dictionary1.ElementAt(k).Value.Item2);
                }
                table.AddRow(tempRow);
            }
            table.Write(Format.MarkDown);
        }
        public static void ErrorOutput(string messegeError)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\a\n " + messegeError);
            ResetColor();
        }
        public static void ErrorOutput(List<Exception> listExceptions)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("\a Количество ошибок: " + listExceptions.Count);
            ForegroundColor = ConsoleColor.Red;
            for (int count = 0; count < listExceptions.Count; count++)
            {
                WriteLine(listExceptions[count].Message);
                WriteLine(listExceptions[count].StackTrace);
            }
            ResetColor();
        }
        public static void SectionName(string info, string type)
        {
            Write($" {type} - \"");
            if(type=="Раздел")
                ForegroundColor = ConsoleColor.Green;
            else if(type=="Действие")
                ForegroundColor = ConsoleColor.Green;
            Write($"{info}");
            ResetColor();
            Write("\"\n");
        }
    }
}
