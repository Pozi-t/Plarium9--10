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
            try
            {
                using (FileStream fs = new("catalog.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, catalog.Data);
                    WriteCommand("Каталог сериализован и сохранен");
                }
            }
            catch (Exception e)
            {
                WriteCommand($"Каталог не удалось сериализован и сохранить. Ошибка : {e.Message}");
            }
        }
        public void ReadCatalog(out Catalog catalog)
        {
            catalog = new();
            try
            {
                using (FileStream fs = new("catalog.xml", FileMode.OpenOrCreate))
                {
                    catalog.Data = (List<Product>)formatter.Deserialize(fs);
                    WriteCommand("Каталог десериализован и введён в эксплатацию");
                }
            }
            catch (Exception e)
            {
                WriteCommand($"Каталог не удалось десериализован и начать использовать. Ошибка : {e.Message}");
            }
        }
        public void ShowCommand(string path)
        {
            using (StreamReader sr = new(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        public static void WriteCommand(string str)
        {
            using (StreamWriter sw = new("log.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine(str + " " + DateTime.Now.ToString());
            }
        }
        public static void WriteLinq(IEnumerable<Product> cat)
        {
            string data = "";
            foreach (var item in cat)
            {
                data += $"{item.Name} {item.Description} {item.Date}\n";
            }
            using (StreamWriter sw = new StreamWriter("data.txt", false, System.Text.Encoding.Default))
            {
                sw.WriteLine(data);
            }
        }
    }
}
