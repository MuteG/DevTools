using System.IO;
using ClosedXML.Excel;
using DevTools.Plugin.CodeLines.Entity;

namespace DevTools.Plugin.CodeLines.DAL
{
    /// <summary>
    /// Excel文件行数计数器
    /// </summary>
    [FileInfo(".xls,.xlsx")]
    public class ExcelCounter : AbstractCounter
    {
        public override void Count(ref CodeLineCount count)
        {
            try
            {
                using (FileStream stream = new FileStream(this.TargetFile, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
                using (XLWorkbook book = new XLWorkbook(stream))
                {
                    foreach (IXLWorksheet sheet in book.Worksheets)
                    {
                        count.Total += sheet.LastRowUsed().RowNumber();
                    }
                }
            }
            catch
            {
                // ignored
            }
        }

        public override string AnnotateLineKeyWord
        {
            get { return string.Empty; }
        }

        public override string AnnotateBlockBeginKeyWord
        {
            get { return string.Empty; }
        }

        public override string AnnotateBlockEndKeyWord
        {
            get { return string.Empty; }
        }
    }
}
