using System.IO;
using DevTools.Plugin.CodeLines.DAL;

namespace DevTools.Plugin.CodeLines.BLL
{
    public class CounterFactory
    {
        public static ICountable Create(string file)
        {
            ICountable counter = null;
            switch (Path.GetExtension(file).ToUpper())
            {
                case ".HTML":
                case ".HTM":
                    counter = new HtmlCounter
                    {
                        TargetFile = file,
                        AnnotateLineKeyWord = "<!DOCTYPE",
                        AnnotateBlockBeginKeyWord = "<!--",
                        AnnotateBlockEndKeyWord = "-->"
                    };
                    break;
                case ".CS":
                    counter = new CSharpCounter
                    {
                        TargetFile = file,
                        AnnotateLineKeyWord = "//",
                        AnnotateBlockBeginKeyWord = "/*",
                        AnnotateBlockEndKeyWord = "*/"
                    };
                    break;
                case ".JAVA":
                    counter = new JavaCounter
                    {
                        TargetFile = file,
                        AnnotateLineKeyWord = "//",
                        AnnotateBlockBeginKeyWord = "/*",
                        AnnotateBlockEndKeyWord = "*/"
                    };
                    break;
                case ".SQL":
                    counter = new SQLCounter
                    {
                        TargetFile = file,
                        AnnotateLineKeyWord = "--",
                        AnnotateBlockBeginKeyWord = "/*",
                        AnnotateBlockEndKeyWord = "*/"
                    };
                    break;
                case ".XLS":
                    counter = new ExcelCounter
                    {
                        TargetFile = file,
                        AnnotateLineKeyWord = string.Empty,
                        AnnotateBlockBeginKeyWord = string.Empty,
                        AnnotateBlockEndKeyWord = string.Empty
                    };
                    break;
                case ".DIFF":
                    counter = new DiffCounter
                    {
                        TargetFile = file,
                        AnnotateLineKeyWord = string.Empty,
                        AnnotateBlockBeginKeyWord = string.Empty,
                        AnnotateBlockEndKeyWord = string.Empty
                    };
                    break;
                case ".XML":
                    counter = new XmlCounter
                    {
                        TargetFile = file,
                        AnnotateLineKeyWord = "<!DOCTYPE",
                        AnnotateBlockBeginKeyWord = "<!--",
                        AnnotateBlockEndKeyWord = "-->"
                    };
                    break;
            }
            return counter;
        }
    }
}
