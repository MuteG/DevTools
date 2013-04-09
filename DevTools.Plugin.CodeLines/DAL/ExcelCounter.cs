using System.IO;
using DevTools.Plugin.CodeLines.Entity;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace DevTools.Plugin.CodeLines.DAL
{
    /// <summary>
    /// Excel文件行数计数器
    /// </summary>
    [FileInfo(".xls")]
    public class ExcelCounter : AbstractCounter
    {
        public override void Count(ref CodeLineCount count)
        {
            using (FileStream stream = new FileStream(this.TargetFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                IWorkbook book = new HSSFWorkbook(stream);
                for (int i = 0; i < book.NumberOfSheets; i++)
                {
                    ISheet sheet = book.GetSheetAt(i);
                    count.Total += sheet.PhysicalNumberOfRows;

                    //TODO 判断图片以及绘制的图形占用了多少行
                }
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
