using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DevTools.Plugin.CodeLines.DAL;

namespace DevTools.Plugin.CodeLines.BLL
{
    public class CounterFactory
    {
        private static Dictionary<string, Type> counterDict = new Dictionary<string, Type>();

        public static ICountable Create(string file)
        {
            ICountable counter = null;

            string ext = Path.GetExtension(file).ToLower();

            if (counterDict.ContainsKey(ext))
            {
                counter = Activator.CreateInstance(counterDict[ext]) as ICountable;
            }
            else
            {
                counter = FindType(ext);
            }

            if (null != counter)
            {
                (counter as AbstractCounter).TargetFile = file;
            }

            return counter;
        }

        private static ICountable FindType(string ext)
        {
            ICountable counter = null;

            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            foreach (Type type in currentAssembly.GetTypes())
            {
                if (type.GetInterface(typeof(ICountable).Name) != null)
                {
                    object[] attrArray = type.GetCustomAttributes(typeof(FileInfoAttribute), false);
                    if (attrArray.Length > 0)
                    {
                        string typeExt = (attrArray[0] as FileInfoAttribute).Extension.ToLower();
                        string[] extArray = typeExt.Split(',');
                        if (Array.Find(extArray, item => item.Equals(ext)) != null)
                        {
                            counter = Activator.CreateInstance(type) as ICountable;
                            foreach (string item in extArray)
                            {
                                counterDict.Add(item.Trim(), type);
                            }
                            break;
                        }
                    }
                }
            }
            return counter;
        }
    }
}
