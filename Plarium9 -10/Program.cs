using System;
using System.Collections.Generic;
using System.IO;

namespace Plarium9__10
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog;
            string str, firstName, secondName, groupParam, ch;
            if (File.Exists("temp\\tempData.xml"))
            {
                do
                {
                    Console.WriteLine("Обнаружен файл экстренного сохранения ?\nЖелаете его выгрузить : yes/not");
                    ch = Console.ReadLine();
                } while (ch != "yes" && ch != "not");
                if (ch == "yes") BD.ReadCatalog(out catalog, "temp\\tempData.xml");
                else BD.ReadCatalog(out catalog, "catalog.xml");
            } else BD.ReadCatalog(out catalog, "catalog.xml");

            
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
            if (ch == "yes") BD.SaveCatalog(catalog, "catalog.xml");
            else BD.WriteCommand("Пользователь отказался сохранить каталог в конце взаимодействия с программой");
            
            do
            {
                Console.WriteLine("Желаете увидеть выборку ?\nВведите : yes/not");
                ch = Console.ReadLine();
            } while (ch != "yes" && ch != "not");
            if (ch == "yes") BD.ShowCommand("data.txt");
        }
    }
}