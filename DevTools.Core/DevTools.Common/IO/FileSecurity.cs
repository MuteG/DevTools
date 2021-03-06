﻿using System.IO;
using System.Security.Cryptography;

namespace DevTools.Common.IO
{
    public static class FileSecurity
    {
        private static readonly byte[] IV = new byte[16] {
            36, 179, 238, 200, 42, 8, 226, 55,
            4, 29, 230, 91, 213, 121, 62, 134
        };

        private static readonly byte[] KEY = new byte[32] {
            154, 126, 163, 24, 48, 53, 181, 216,
            226, 99, 113, 219, 160, 56, 247, 100,
            115, 16, 60, 143, 191, 214, 82, 121,
            141, 94, 25, 206, 158, 0, 219, 49
        };

        public static void EncryptFile(string file)
        {
            string content = string.Empty;
            FileStream readStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
            using (StreamReader reader = new StreamReader(readStream))
            {
                content = reader.ReadToEnd();
            }

            CryptoStream cryptoStream = GetCryptoStreamForWrite(file);
            using (StreamWriter writer = new StreamWriter(cryptoStream))
            {
                writer.Write(content);
            }
        }

        public static CryptoStream GetCryptoStreamForWrite(string file)
        {
            RijndaelManaged security = new RijndaelManaged();
            security.IV = IV;
            security.Key = KEY;

            FileStream writeSteam = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.Read);
            CryptoStream cryptoStream = new CryptoStream(writeSteam,
                security.CreateEncryptor(), CryptoStreamMode.Write);
            
            return cryptoStream;
        }

        public static void DecryptFile(string file)
        {
            CryptoStream cryptoStream = GetCryptoStreamForRead(file);
            string content = string.Empty;
            using (StreamReader reader = new StreamReader(cryptoStream))
            {
                content = reader.ReadToEnd();
            }

            FileStream writeSteam = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.Read);
            using (StreamWriter writer = new StreamWriter(writeSteam))
            {
                writer.Write(content);
            }
        }

        public static CryptoStream GetCryptoStreamForRead(string file)
        {
            RijndaelManaged security = new RijndaelManaged();
            security.IV = IV;
            security.Key = KEY;

            FileStream readStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
            CryptoStream cryptoStream = new CryptoStream(readStream,
                security.CreateDecryptor(), CryptoStreamMode.Read);

            return cryptoStream;
        }
    }
}
