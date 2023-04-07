using System;
using System.Collections;
using System.Collections.Generic;

namespace HostelProject._Model
{
    public class YieldObjects
    {
        public string nameObject;
        public List<object> listObjects = new List<object>();
        public YieldObjects(string nameObject, List<object> listObjects)
        {
            this.nameObject = nameObject;
            this.listObjects = listObjects;
        }
        public IEnumerator GetEnumerator()
        {
            int errorNumObjects = 0;
            foreach (object item in listObjects)
            {
                if (item.GetType().Name.ToString() == nameObject)
                {
                    yield return item;
                }
                else
                    errorNumObjects++;
            }
            if (errorNumObjects == listObjects.Count)
            { throw new Exception($"Класс {nameObject} не найден!"); }
        }
    }
}
