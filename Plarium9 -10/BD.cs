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
    public class BD
    {
        public static void SaveCatalog(Catalog catalog,string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Product>));
            try
            {
                using (FileStream fs = new(path, FileMode.OpenOrCreate))
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
        public static void ReadCatalog(out Catalog catalog, string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Product>));
            catalog = new();
            try
            {
                using (FileStream fs = new(path, FileMode.OpenOrCreate))
                {
                    catalog.Data = (List<Product>)formatter.Deserialize(fs);
                    WriteCommand("Каталог десериализован и введён в эксплатацию");
                }
                if (File.Exists("temp\\tempData.xml")) File.Delete("temp\\tempData.xml");
            }
            catch (Exception e)
            {
                WriteCommand($"Каталог не удалось десериализован и начать использовать. Ошибка : {e.Message}");
            }
        }
        public static void ShowCommand(string path)
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
