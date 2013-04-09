using System;

namespace DevTools.Plugin.CodeLines.DAL
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class FileInfoAttribute : Attribute
    {
        /// <summary>
        /// 文件扩展名（多个扩展名之间用英文半角逗号隔开）
        /// </summary>
        /// <example>.abc,.def,.ghi</example>
        public string Extension { get; set; }

        /// <summary>
        /// 用指定的属性来初始化FileInfo特性的新实例
        /// </summary>
        /// <param name="ext">文件扩展名（多个扩展名之间用英文半角逗号隔开）</param>
        /// <example>.abc,.def,.ghi</example>
        public FileInfoAttribute(string ext)
        {
            this.Extension = ext;
        }
    }
}
