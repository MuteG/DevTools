using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DevTools.Plugin.CodeLines.DAL;

namespace DevTools.Plugin.CodeLines.BLL
{
    public static class CodeFileFactory
    {
        private static Dictionary<string, Type> counterDict = new Dictionary<string, Type>();

        public static AbstractCodeFile Create(string file)
        {
            AbstractCodeFile codeFile = null;

            string ext = Path.GetExtension(file).ToLower();

            if (counterDict.ContainsKey(ext))
            {
                codeFile = Activator.CreateInstance(counterDict[ext]) as AbstractCodeFile;
            }
            else
            {
                codeFile = FindType(ext);
            }

            if (null == codeFile)
            {
                counterDict.Add(ext, typeof(NormalCodeFile));
                codeFile = new NormalCodeFile();
            }

            codeFile.File = file;

            return codeFile;
        }

        private static AbstractCodeFile FindType(string ext)
        {
            AbstractCodeFile codeFile = null;

            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            foreach (Type type in currentAssembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(AbstractCodeFile)))
                {
                    object[] attrArray = type.GetCustomAttributes(typeof(FileInfoAttribute), false);
                    if (attrArray.Length > 0)
                    {
                        string typeExt = (attrArray[0] as FileInfoAttribute).Extension.ToLower();
                        string[] extArray = typeExt.Split(',');
                        if (Array.Find(extArray, item => item.Equals(ext)) != null)
                        {
                            codeFile = Activator.CreateInstance(type) as AbstractCodeFile;
                            foreach (string item in extArray)
                            {
                                counterDict.Add(item.Trim(), type);
                            }
                            break;
                        }
                    }
                }
            }
            return codeFile;
        }
    }
}
