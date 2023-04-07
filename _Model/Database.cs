using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HostelProject._Model;
using HostelProject._Model._Classes;

namespace HostelProject._Model
{
    public class Database
    {
        static public List<object> allObjects = new List<object>();
        static public List<object> GettingData()
        {
            WorkingWithAFile file = new WorkingWithAFile("DataBase");
            allObjects.Clear();
            allObjects = file.ReadingFile();

            return allObjects;
        }
        public static List<object> IteratorObjects(ref List<object> listObjects, string typeOfObject)
        {
            YieldObjects yieldObjects = new YieldObjects(typeOfObject, listObjects);

            List<object> listTemp = new List<object>();
            foreach (object objects in yieldObjects)
            {
                listTemp.Add(objects);
            }
            return listTemp;
        }
        public static byte CheckUser(string login, string password)
        {
            GettingData();
            Search users = new Search();
            List<object> temp = new List<object>();
            temp = users.RequestSearch(allObjects, "Administrator", "Login", login);
            if (temp.Count == 1)
            {
                if (users.RequestSearch(temp, "Administrator", "Password", password).Count == 1)
                { return 0; }
                else return 2;
            }
            else return 1;
        }
        public static List<object> LiveNow(List<object> list)
        {
            List<object> listTemp = new List<object>();
            for (int i = 0; i < list.Count; i++)
            {
                Type type = list[i].GetType();
                if (type.Name != "Request") continue;
                if (((Request)list[i]).BookedDateStart <= DateTime.Now && ((Request)list[i]).BookedDateEnd >= DateTime.Now)
                { listTemp.Add(list[i]); }
            }
            return listTemp;
        }
        public static List<object> EdinInfo(List<object> list, string nameObject, int idObject, string characteristic, string value)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Type type = list[i].GetType();
                if (type.Name == nameObject)
                {
                    PropertyInfo[] myPropertyInfo = type.GetProperties();

                    for (int j = 0; j < myPropertyInfo.Length; j++)
                    {
                        if (myPropertyInfo[j].Name == "Id" )
                        {
                            if ((int)myPropertyInfo[j].GetValue(list[i]) == idObject)
                            {
                                for (int k = 0; k < myPropertyInfo.Length; k++)
                                {
                                    if (myPropertyInfo[k].Name == characteristic)
                                    {
                                        if (myPropertyInfo[k].CanWrite)
                                        {
                                            myPropertyInfo[k].SetValue(list[i], Convert.ChangeType(value, myPropertyInfo[k].PropertyType));
                                            return list;
                                        }
                                        else throw new Exception($"Редактирование характеристики с названием \"{characteristic}\" в классе \"{nameObject}\" запрещено!");
                                    }
                                }
                                throw new Exception($"Характеристики с названием \"{characteristic}\" в классе \"{nameObject}\" не найдено!");
                            }
                            else break;
                        }
                    }
                }
            }
            throw new Exception($"Класс с названием \"{nameObject}\" не найден!");
        }
    }
}