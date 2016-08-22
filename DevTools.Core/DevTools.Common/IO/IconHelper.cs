using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DevTools.Common.IO
{
    public static class IconHelper
    {
        public const uint SHGFI_ICON = 0x000000100;
        public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;
        public const uint SHGFI_OPENICON = 0x000000002;
        public const uint SHGFI_SMALLICON = 0x000000001;
        public const uint SHGFI_LARGEICON = 0x000000000;
        public const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        [DllImport("User32.dll")]
        public static extern int DestroyIcon(IntPtr hIcon);

        public static Icon GetSmallIcon(string fileName)
        {
            return GetIcon(fileName, SHGFI_SMALLICON);
        }

        public static Icon GetLargeIcon(string fileName)
        {
            return GetIcon(fileName, SHGFI_LARGEICON);
        }

        private static Icon GetIcon(string fileName, uint flags)
        {
            SHFILEINFO shinfo = new SHFILEINFO();
            IntPtr hImgSmall = SHGetFileInfo(fileName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | flags);

            Icon icon = (Icon)System.Drawing.Icon.FromHandle(shinfo.hIcon).Clone();
            DestroyIcon(shinfo.hIcon);
            return icon;
        }

        public static Bitmap GetBitmap(string fileName)
        {
            SHFILEINFO shinfo = new SHFILEINFO();
            IntPtr hImgSmall = SHGetFileInfo(fileName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);

            Bitmap icon = (Bitmap)System.Drawing.Bitmap.FromHicon(shinfo.hIcon).Clone();
            DestroyIcon(shinfo.hIcon);
            return icon;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public IntPtr iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    }
}
