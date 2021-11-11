using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Plarium9__10
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Catalog catalog;
            string str, firstName, secondName, groupParam, ch;
            BD db = new("catalog.xml");
            if (File.Exists("temp\\tempData.xml"))
            {
                do
                {
                    Console.WriteLine("Обнаружен файл экстренного сохранения ?\nЖелаете его выгрузить : yes/not");
                    ch = Console.ReadLine();
                } while (ch != "yes" && ch != "not");
                if (ch == "yes")
                {
                    db.Path = "temp\\tempData.xml";
                }
            }
            catalog = await db.ReadAsync();

            Console.WriteLine("Введите название продукта перечень параметров которого вы хотите увидеть");
            str = Console.ReadLine();
            if(catalog[str] != null) catalog[str].ProductGroup.ShowParamsGroups();
            
            Console.WriteLine("Введите с каким параметром товар вас не интересует");
            str = Console.ReadLine();
            
            catalog.ShowWithoutParameter(str);
            
            Console.WriteLine("Введите какую группу вы хотите вывести");
            str = Console.ReadLine();
            catalog.ShowWithParameter(str);
            Console.ReadKey();
            catalog.Show();
            Console.WriteLine("Введите продукты c каким параметром удалять");
            str = Console.ReadLine();
            catalog.Remove(str);
            

            catalog.Show();

            Console.WriteLine("Введите в какой товар вы хотите переместить группу пораметров");
            firstName = Console.ReadLine();
            Console.WriteLine("Введите из какого товара вы хотите переместить группу пораметров");
            secondName = Console.ReadLine();
            Console.WriteLine("Введите название группы пораметров, которую перемещаем");
            groupParam = Console.ReadLine();

            catalog.MoveParameterGroup(firstName, secondName, groupParam);

            Console.WriteLine("\n\nПроизошла замена\n\n");
            
            catalog.Show();
            do
            {
                Console.WriteLine("Желаете сохранить результат работы с каталогом ?\nВведите : yes/not");
                ch = Console.ReadLine();
            } while (ch != "yes" && ch != "not");
            if (ch == "yes"){
                db.Path = "catalog.xml";
                Thread saveThread = new(new ParameterizedThreadStart(db.SaveCatalog));
                saveThread.Start(catalog);
            }
            
            do
            {
                Console.WriteLine("Желаете увидеть выборку ?\nВведите : yes/not");
                ch = Console.ReadLine();
            } while (ch != "yes" && ch != "not");
            if (ch == "yes"){
                Thread myThread = new(new ParameterizedThreadStart(BD.ShowFile));
                myThread.Start("data.txt");
            }
        }
    }
}