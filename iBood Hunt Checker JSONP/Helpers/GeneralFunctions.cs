using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace iBood_Hunt_Checker.Helpers
{
    public static class GeneralFunctions
    {
        public static void ExitApplication()
        {
            if (Application.MessageLoop)
            {
                // WinForms app
                Application.Exit();
            }
            else
            {
                // Console app
                Environment.Exit(1);
            }

        }

        public static string Serialize<T>(T o)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            StringWriter stringwriter = new StringWriter();
            XmlWriter xmlwriter = XmlWriter.Create(stringwriter, new XmlWriterSettings());
            ser.Serialize(xmlwriter, o);
            return XDocument.Parse(stringwriter.ToString()).ToString();
        }

        public static T Deserialize<T>(string input)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
                return (T)ser.Deserialize(sr);
        }
    }
}
