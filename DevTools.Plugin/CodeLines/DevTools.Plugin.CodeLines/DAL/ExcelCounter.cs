using System.IO;
using DevTools.Plugin.CodeLines.Entity;
using OfficeOpenXml;

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
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    ExcelWorkbook book = package.Workbook;
                    foreach (ExcelWorksheet sheet in book.Worksheets)
                    {
                        if (sheet.Dimension != null)
                        {
                            count.Total += sheet.Dimension.Rows;
                        }
                    }
                }
            }
            catch
            {
                
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
