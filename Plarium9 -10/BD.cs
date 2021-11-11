using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
namespace Plarium9__10
{
    public class BD
    {
        private string path;
        public string Path { get { return path; } set { path = value; } }
        private readonly Mutex MutexObj;
        private readonly XmlSerializer Formatter;
        public BD(string path)
        {
            Path = path;
            MutexObj = new();
            Formatter = new(typeof(List<Product>));
        }
        public void SaveCatalog(object cat)
        {
            Catalog catalog = (Catalog)cat;
            MutexObj.WaitOne();
            try
            {
                using (FileStream fs = new(Path, FileMode.OpenOrCreate))
                {
                    Formatter.Serialize(fs, catalog.Data);
                    Thread myThread = new(new ParameterizedThreadStart(WriteCommand));
                    myThread.Start("Каталог сериализован и сохранен");
                }
            }
            catch (Exception e)
            {
                Thread myThread = new(new ParameterizedThreadStart(WriteCommand));
                myThread.Start($"Каталог не удалось сериализован и сохранить. Ошибка : {e.Message}");
            }
            MutexObj.ReleaseMutex();
        }
        public Catalog ReadCatalog()
        {
            MutexObj.WaitOne();
            Catalog catalog = new();
            try
            {
                using (FileStream fs = new(Path, FileMode.OpenOrCreate))
                {
                    catalog.Data = (List<Product>)Formatter.Deserialize(fs);
                    Thread myThread = new(new ParameterizedThreadStart(WriteCommand));
                    myThread.Start("Каталог десериализован и введён в эксплатацию");
                }
                if (File.Exists("temp\\tempData.xml")) File.Delete("temp\\tempData.xml");
            }
            catch (Exception e)
            {
                Thread myThread = new(new ParameterizedThreadStart(WriteCommand));
                myThread.Start($"Каталог не удалось десериализован и начать использовать. Ошибка : {e.Message}");
            }
            MutexObj.ReleaseMutex();
            return catalog;
        }
        public async Task<Catalog> ReadAsync()
        {
            return await Task.Run(() => ReadCatalog());
        }
        public static void ShowFile(object s)
        {
            string path = (string)s;
            using (StreamReader sr = new(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        public static void WriteCommand(object s)
        {
            string str = (string)s;
            using (StreamWriter sw = new("log.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine(str + " " + DateTime.Now.ToString());
            }
        }
        public static void WriteLinq(object cat)
        {
            IEnumerable<Product> catalog = (IEnumerable<Product>)cat;
            string data = "";
            foreach (var item in catalog)
            {
                data += $"{item.Name} {item.Description} {item.Date}\n";
            }
            using (StreamWriter sw = new("data.txt", false, System.Text.Encoding.Default))
            {
                sw.WriteLine(data);
            }
        }
    }
}
