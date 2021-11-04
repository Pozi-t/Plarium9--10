using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Plarium9__10
{
    class BD
    {
        XmlSerializer formatter;
        public BD()
        {
            formatter = new XmlSerializer(typeof(List<Product>));
        }
        public void SaveCatalog(Catalog catalog)
        {
            using (FileStream fs = new("catalog.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, catalog.Data);
                Console.WriteLine("Объект сериализован");
            }
        }
        public void ReadCatalog(out Catalog catalog)
        {
            catalog = new();
            using (FileStream fs = new("catalog.xml", FileMode.OpenOrCreate))
            {
                catalog.Data = (List<Product>)formatter.Deserialize(fs);
            }
        }
        public void ShowCommand()
        {

        }
        public void WriteCommand(string str)
        {
            string text = "Привет мир!\nПока мир...\n";

            using (StreamWriter sw = new("log.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine(str);
            }
        }
    }
}
