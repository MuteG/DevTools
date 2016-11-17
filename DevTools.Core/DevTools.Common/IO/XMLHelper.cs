using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DevTools.Common.IO
{
    public class XMLHelper
    {
        public string XMLFile { get; private set; }

        public bool IsSerurity { get; private set; }

        public XMLHelper(string file, bool serurity)
        {
            this.XMLFile = file;
            this.IsSerurity = serurity;
        }

        public XMLHelper(string file)
            : this(file, false)
        {
        }

        public object Load(Type type)
        {
            Stream readStream = Stream.Null;
            if (this.IsSerurity)
            {
                readStream = FileSecurity.GetCryptoStreamForRead(this.XMLFile);
            }
            else
            {
                readStream = new FileStream(this.XMLFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            try
            {
                using (XmlReader reader = XmlReader.Create(readStream))
                {
                    XmlSerializer xs = XmlSerializer.FromTypes(new[] { type })[0];
                    return xs.Deserialize(reader);
                }
            }
            finally
            {
                if (null != readStream)
                {
                    readStream.Close();
                }
            }
        }

        public void Save(object obj)
        {
            if (!File.Exists(this.XMLFile))
            {
                File.Create(this.XMLFile).Close();
            }
            Stream writeStream = Stream.Null;
            if (this.IsSerurity)
            {
                writeStream = FileSecurity.GetCryptoStreamForWrite(this.XMLFile);
            }
            else
            {
                writeStream = new FileStream(this.XMLFile, FileMode.Open, FileAccess.Write, FileShare.Read);
            }
            try
            {
                using (XmlWriter writer = XmlWriter.Create(writeStream))
                {
                    XmlSerializer xs = XmlSerializer.FromTypes(new[] { obj.GetType() })[0];
                    xs.Serialize(writer, obj);
                }
            }
            finally
            {
                if (null != writeStream)
                {
                    writeStream.Close();
                }
            }
        }
    }
}
