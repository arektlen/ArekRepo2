using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace OrdersRegistration.WPF.Infrastructure
{
    public class XMLSerialization
    {
        public static void Serialization(Settings settings, string path)
        {
            XmlSerializer oSerializer = new XmlSerializer(typeof(Settings));
            StreamWriter sw = new StreamWriter(path);
            oSerializer.Serialize(sw, settings);
            sw.Close();
        }

        public static Settings Deserialization(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);
            var result = (Settings)serializer.Deserialize(reader);
            fs.Close();

            return result;
        }
    }
}
