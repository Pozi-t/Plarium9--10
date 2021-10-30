using System;
using System.Collections.Generic;

namespace Plarium9__10
{
    class Program
    {
        static void Main(string[] args)
        {
            Сatalog catalog = new();
            string str, firstName, secondName, groupParam;

            Console.WriteLine("Введите название продукта перечень параметров которого вы хотите увидеть");
            str = Console.ReadLine();
            catalog[str].ProductGroup.ShowParamsGroups();

            Console.WriteLine("Введите с каким параметром товар вас не интересует");
            str = Console.ReadLine();
            foreach (Product product in catalog)
            {
                if (!product.CheckProductParam(str)) Console.WriteLine($"Продукт {product.Name} не содержит параметр {str}");

            }

            Console.WriteLine("Введите какую группу вы хотите вывести");
            str = Console.ReadLine();
            foreach (Product product in catalog)
            {
                if (product.CheckGroup(str))
                {
                    Console.WriteLine($"{product.Name} входит в выбранную группу");
                    product.ShowInfo();
                }
            }

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



        }
    }
}