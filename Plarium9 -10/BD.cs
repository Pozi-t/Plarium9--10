using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Plarium9__10
{
    class BD
    {
        public BinaryFormatter Formatter;

        public BD() => Formatter = new();
        
        public void Save(Catalog catalog)
        {
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                Formatter.Serialize(fs, catalog);

                Console.WriteLine("Объект сериализован");
            }
        }

    }
}
