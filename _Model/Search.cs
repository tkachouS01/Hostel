using System;
using System.Collections.Generic;
using System.Reflection;

namespace HostelProject._Model
{
    class Search : ISearch
    {
        public List<object> RequestSearch(List<object> listObjects,
            string nameObject, string nameFeature, string valueFeature)
        {
            List<object> listTemp = new List<object>();
            bool isTheObjectLocated = false,
                isThePropertyLocated = false;

            for (int k = 0; k < listObjects.Count; k++)
            {
                Type type = listObjects[k].GetType();
                if (type.Name == nameObject)
                {
                    isTheObjectLocated = true;
                    PropertyInfo[] myPropertyInfo = type.GetProperties();
                    for (int i = 0; i < myPropertyInfo.Length; i++)
                    {
                        if (myPropertyInfo[i].Name == nameFeature)
                        {
                            isThePropertyLocated = true;
                            if (Convert.ToString(myPropertyInfo[i].GetValue(listObjects[k])) == valueFeature)
                            {
                                listTemp.Add(listObjects[k]);
                                break;
                            }
                        }
                    }
                    if (!isThePropertyLocated)
                        break;
                }
            }
            if (!isTheObjectLocated)
                throw new Exception($"101");//Объект с названием {nameObject} не найден.

            else if (!isThePropertyLocated)
                throw new Exception($"102");//Характеристика с названием {nameFeature} не найдена.

            else
                return listTemp.Count == 0
                    ? throw new Exception
                    ("103")
                    : listTemp; //$"Характеристики {nameFeature} с значением {valueFeature} не найдено.
        }
    }
}
