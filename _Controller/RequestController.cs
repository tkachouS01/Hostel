using HostelProject._Model;
using HostelProject._Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using static System.Console;
namespace HostelProject._Controller
{
    public class RequestController
    {
        public static void AcceptingRequest()
        {
            WriteLine(" Вход в систему");
            while (true)
            {
                Write("\n Логин: "); string login = ReadLine();
                Write(" Пароль: "); string password = ReadLine();
                if (Database.CheckUser(login, password) == 0) break;
                switch (Database.CheckUser(login, password))
                {
                    case 1: WriteLine(" Неверный логин"); break;
                    case 2: WriteLine(" Неверный пароль"); break;
                }
            } WriteLine("\n Вход выполнен успешно!");
            List<object> listObjects = new List<object>();
            List<object> listTemp = new List<object>();
            while (true)
            {
                string[] info = { "Получить данные", "Сохранить данные", "Клиенты", "Работники", "Заявки", "Комнаты", "Отчёты", "Очистить экран", "Выйти" };
                Print.BackgroundInformation(info);
                string numMenu = ReadLine();
                try
                {
                    if (int.Parse(numMenu) <= info.Length && int.Parse(numMenu) > 0)
                    {
                        Print.SectionName(info[int.Parse(numMenu) - 1], "Раздел");
                        switch (numMenu)
                        {
                            case "1":
                                { if (CheckingForANullList(listObjects = listTemp = Database.GettingData())) WriteLine(" Данные успешно получены."); break; }
                            case "2":
                                { WorkingWithAFile.WritingToFile(listObjects); WriteLine(" Данные успешно сохранены."); break; }
                            case "3":
                                {
                                    info = new string[] { "Вывод всех клиентов", "Вывод клиентов проживающих на данный момент", "Поиск", "Добавить", "Редактировать", "Удалить", "Назад", "Выйти" };
                                    Print.BackgroundInformation(info);
                                    numMenu = ReadLine();

                                    if (int.Parse(numMenu) < info.Length && int.Parse(numMenu) > 0)
                                    {
                                        Print.SectionName(info[int.Parse(numMenu) - 1], "Действие");
                                        listTemp = Database.IteratorObjects(ref listObjects, "Client");
                                        switch (numMenu)
                                        {
                                            case "1": if (CheckingForANullList(listTemp)) Print.OutputAsList(listTemp); break;
                                            case "2": listTemp = Database.LiveNow(listObjects); break;
                                            case "3": listTemp = SearchRequest(listTemp, "Client"); if (CheckingForANullList(listTemp)) Print.OutputAsList(listTemp); break;
                                            case "4": listTemp = AddRequest(listObjects, "Client"); break;
                                            case "5": listObjects = EditRequest(listObjects, "Client"); break;
                                            case "6": RemoveRequest(listObjects, "Client"); break;
                                            case "7": break;
                                            case "8": return;
                                        }
                                    }
                                    else WriteLine("Неверный запрос");
                                    break;
                                }
                            case "4":
                                {
                                    info = new string[] { "Вывод всех работников", "Поиск", "Добавить", "Редактировать", "Удалить", "Назад", "Выйти" };
                                    Print.BackgroundInformation(info);
                                    numMenu = ReadLine();

                                    if (int.Parse(numMenu) < info.Length && int.Parse(numMenu) > 0)
                                    {
                                        Print.SectionName(info[int.Parse(numMenu) - 1], "Действие");
                                        listTemp = Database.IteratorObjects(ref listObjects, "Worker");

                                        switch (numMenu)
                                        {
                                            case "1": if (CheckingForANullList(listTemp)) Print.OutputAsList(listTemp); break;
                                            case "2": listTemp = SearchRequest(listTemp, "Worker"); if (CheckingForANullList(listTemp)) Print.OutputAsList(listTemp); break;
                                            case "3": listTemp = AddRequest(listObjects, "Worker"); break;
                                            case "4": listObjects = EditRequest(listObjects, "Worker"); break;
                                            case "5": RemoveRequest(listObjects, "Worker"); break;
                                            case "6": break; ;
                                            case "7": return;
                                        }
                                    }
                                    else WriteLine("Неверный запрос");
                                    break;
                                }
                            case "5":
                                {
                                    info = new string[] { "Вывод всех заявок", "Поиск", "Добавить", "Редактировать", "Удалить", "Назад", "Выйти" };
                                    Print.BackgroundInformation(info);
                                    numMenu = ReadLine();

                                    if (int.Parse(numMenu) < info.Length && int.Parse(numMenu) > 0)
                                    {
                                        Print.SectionName(info[int.Parse(numMenu) - 1], "Действие");
                                        listTemp = Database.IteratorObjects(ref listObjects, "Request");

                                        switch (numMenu)
                                        {
                                            case "1": if (CheckingForANullList(listTemp)) Print.OutputAsList(listTemp); break;
                                            case "2": listTemp = SearchRequest(listTemp, "Request"); if (CheckingForANullList(listTemp)) Print.OutputAsList(listTemp); break;
                                            case "3": listTemp = AddRequest(listObjects, "Request"); break;
                                            case "4": listObjects = EditRequest(listObjects, "Request");  break;
                                            case "5": RemoveRequest(listObjects, "Request"); break;
                                            case "6": break;
                                            case "7": return;
                                        }
                                    }
                                    else WriteLine("Неверный запрос");
                                    break;
                                }
                            case "6":
                                {
                                    listTemp = Database.IteratorObjects(ref listObjects, "Room");

                                    info = new string[] { "Вывод всех номеров", "Вывод всех свободных номеров", "Поиск", "Добавить", "Редактировать", "Удалить", "Назад", "Выйти" };
                                    Print.BackgroundInformation(info);
                                    numMenu = ReadLine();

                                    if (int.Parse(numMenu) < info.Length && int.Parse(numMenu) > 0)
                                    {
                                        Print.SectionName(info[int.Parse(numMenu) - 1], "Действие");

                                        switch (numMenu)
                                        {
                                            case "1": if (CheckingForANullList(listTemp)) Print.OutputAsList(listTemp); break;
                                            case "2":
                                                {
                                                    try 
                                                    {
                                                        
                                                    }
                                                    catch(Exception ex)
                                                    { }
                                                    break; 
                                                }
                                            case "3": listTemp = SearchRequest(listTemp, "Room"); if (CheckingForANullList(listTemp)) Print.OutputAsList(listTemp); break;
                                            case "4": listTemp = AddRequest(listObjects, "Room"); break;
                                            case "5": listObjects = EditRequest(listObjects, "Room"); break;
                                            case "6": RemoveRequest(listObjects, "Room");  break;
                                            case "7": break;
                                            case "8": return;
                                        }
                                    }
                                    else WriteLine("Неверный запрос");
                                    break;
                                }
                            case "7":
                                {
                                    WriteLine($" Количество клиентов: {Database.IteratorObjects(ref listObjects, "Client").Count}\n" +
                                        $" Количество работников: {Database.IteratorObjects(ref listObjects, "Worker").Count}\n" +
                                        $" Количество комнат: {Database.IteratorObjects(ref listObjects, "Room").Count}\n" +
                                        $" Количество заявок: {Database.IteratorObjects(ref listObjects, "Request").Count}");
                                    info = new string[] { "Назад", "Выйти" };
                                    Print.BackgroundInformation(info);
                                    numMenu = ReadLine();
                                    switch (numMenu)
                                    {
                                        case "1": break;
                                        case "2": return;
                                        default: break;
                                    }
                                    break;
                                }
                            case "8":
                                {
                                    Clear();
                                    break;
                                }
                            case "9":
                                {
                                    return;
                                }
                        }
                    }
                    else WriteLine("Неверный запрос");
                }

                catch (Exception ex)
                { Print.ErrorOutput(ex.Message); }
            }
        }
        public static bool CheckingForANullList(List<object> listObjects)
        {
            if (listObjects.Count == 0)
            { Print.ErrorOutput("Данных нет. Выполнить действие невозможно."); return false; }
            else
                return true;
        }
        public static List<object> SearchRequest(List<object> list, string nameClass)
        {
            WriteLine(" Формат (поле=значение)");
            string str = ReadLine();
            if (Regex.IsMatch(str, @"^(\w+)=(.+)$")) // поиск
            {
                Match match = Regex.Match(str, @"^(\w+)=(.+)$");
                Search search = new Search();

                return search.RequestSearch(list, nameClass, match.Groups[1].Value, match.Groups[2].Value);
            }
            else throw new Exception("Не соответствует формату!");
        }
        public static List<object> EditRequest(List<object> list, string nameClass)
        {
            WriteLine(" Выберите изменяемую характеристику класса");
            WriteLine(" Формат (id поле=значение)");
            string str = ReadLine();
            if (Regex.IsMatch(str, @"^(.+) (\w+)=(.+)$"))
            {
                Match match = Regex.Match(str, @"^(.+) (\w+)=(.+)$");
                List<object> listTemp = Database.EdinInfo(list, nameClass, int.Parse(match.Groups[1].Value), match.Groups[2].Value, match.Groups[3].Value);
                WriteLine(" Изменение проведено успешно!");
                return listTemp;
            }
            else throw new Exception("Не соответствует формату!");
        }
        private delegate object myDeleg(Dictionary<string, object> objectFeatures);
        public static List<object> AddRequest(List<object> list, string strClass)
        {
            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            Dictionary<string, myDeleg> listFeatures = new Dictionary<string, myDeleg>
            {
                ["Administrator"] = new myDeleg(СreatingObjects.CreatingAdministrator),
                ["Worker"] = new myDeleg(СreatingObjects.CreatingWorker),
                ["Client"] = new myDeleg(СreatingObjects.CreatingClient),
                ["Room"] = new myDeleg(СreatingObjects.CreatingRoom),
                ["Request"] = new myDeleg(СreatingObjects.CreatingRequest)
            };
            List<int> idList = new List<int>();
            for(int i=0;i<list.Count;i++)
            {
                Type type = list[i].GetType();
                if(type.Name=="Room")
                {
                    PropertyInfo[] myPropertyInfo = type.GetProperties();
                    for(int j=0;j<myPropertyInfo.Count();j++)
                    {
                        if (myPropertyInfo[j].Name == "Id")
                            idList.Add(Convert.ToInt32(myPropertyInfo[j].GetValue(list[i])));
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                Type type = list[i].GetType();
                if (type.Name == strClass)
                {
                    PropertyInfo[] myPropertyInfo = type.GetProperties();
                    for (int j = 0; j < myPropertyInfo.Length; j++)
                    {
                        if (myPropertyInfo[j].Name == "Characteristix")
                        {
                            WriteLine($" Введите значения характеристик для нового объекта класса {strClass}");
                            Dictionary<string, Tuple<string, object>> dictionary = ((Dictionary<string, Tuple<string, object>>)myPropertyInfo[j].GetValue(list[i]));
                            
                            for (int k = 0; k < dictionary.Count; k++)
                            {
                                if(strClass == "Room" && dictionary.ElementAt(k).Key == "Id")
                                { continue;  }    
                                if(dictionary.ElementAt(k).Key != "Id") 
                                    Write($" {dictionary.ElementAt(k).Value.Item1}: ");
                                object tempVal;
                                if (dictionary.ElementAt(k).Key == "Id")
                                    tempVal = LastId(list, type) + 1;
                                else tempVal = ReadLine();
                                keyValues.Add(dictionary.ElementAt(k).Key, Convert.ChangeType(tempVal,myPropertyInfo[k].PropertyType));
                            }
                            if(strClass == "Room")
                            {
                                int numFloor = 0;
                                for(int h=0;h<keyValues.Count;h++)
                                {
                                    if (keyValues.ElementAt(h).Key == "Floor") { numFloor = h; break; }
                                }
                                int floor = Convert.ToInt32( keyValues.ElementAt(numFloor).Value);
                                int max = idList[0] % 100;
                                for (int a=0;a<idList.Count;a++)
                                {
                                    if(((int)(idList[a]/100))==floor)
                                    {
                                        if (idList[a] % 100 > max) max = idList[a] % 100;
                                    }
                                }
                                keyValues.Add("Id", floor*100 + max+1);
                            }
                            list.Add(listFeatures[strClass](keyValues));
                            
                            WriteLine(" Добавление проведено успешно!");
                            return list;
                        }
                    }
                }
            }
            throw new Exception($"Класс {strClass} не найден!");
        }
        public static int LastId(List<object> list, Type typeClass)
        {
            PropertyInfo[] myPropertyInfo = typeClass.GetProperties();
            int numPropertyId = 0;
            for(int i=0;i<myPropertyInfo.Count();i++)
            {
                if(myPropertyInfo[i].Name == "Id")
                { numPropertyId = i;break; }
            }
            for (int i=list.Count-1;i>=0;i--)
            {
                Type type = list[i].GetType();
                if (type == typeClass)
                {
                    myPropertyInfo = type.GetProperties();
                    return (int)myPropertyInfo[numPropertyId].GetValue(list[i]);
                }
            }
            return 0;
        }
        public static List<object> RemoveRequest(List<object> listObjects, string className)
        {
            Write(" Выберите идентификатор сущности для удаления: ");
            string strID = ReadLine();
            WriteLine();
            listObjects.RemoveAt(NumObjectInList(listObjects, className, "Id", strID));

            return listObjects;
        }
        public static int NumObjectInList(List<object> listObjects, string className, string nameProperty, string valueProperty)
        {
            for (int i = 0; i < listObjects.Count(); i++)
            {
                Type type = listObjects[i].GetType();
                if (type.Name == className)
                {
                    PropertyInfo[] myPropertyInfo = type.GetProperties();
                    if ((int)myPropertyInfo[NumProperty(listObjects, className, nameProperty)].GetValue(listObjects[i]) == Convert.ToInt32(valueProperty))
                        return i;
                }
            }
            throw new Exception($"Значение {valueProperty} свойства {nameProperty} класса {className} не найдено!");
        }
        public static int NumProperty(List<object> listObjects, string className, string nameProperty)
        {
            for (int i = 0; i < listObjects.Count(); i++)
            {
                Type type = listObjects[i].GetType();
                if (type.Name == className)
                {
                    PropertyInfo[] myPropertyInfo = type.GetProperties();
                    for(int j=0;j<myPropertyInfo.Count();j++)
                    {
                        if (myPropertyInfo[j].Name == nameProperty) return j;
                    }
                    throw new Exception($"Свойство {nameProperty} в классе {className} не найдено!");
                }
            }
            throw new Exception($"Класс {className} не найден!");
        }
    }
}