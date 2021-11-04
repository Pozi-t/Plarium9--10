using System;
using System.Collections.Generic;

namespace Plarium9__10
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
 
        // стандартный конструктор без параметров
        public Person()
        { }
 
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog;
            string str, firstName, secondName, groupParam;            
            BD bd = new();
            bd.WriteCommand("Привет gbljh");
            //bd.ReadCatalog(out catalog);
            //bd.Save(catalog);
            //catalog.Show();
            /*
            Console.WriteLine("Введите название продукта перечень параметров которого вы хотите увидеть");
            str = Console.ReadLine();
            catalog[str].ProductGroup.ShowParamsGroups();
            
            Console.WriteLine("Введите с каким параметром товар вас не интересует");
            str = Console.ReadLine();
            
            catalog.ShowWithoutParameter(str);
            
            Console.WriteLine("Введите какую группу вы хотите вывести");
            str = Console.ReadLine();
            catalog.ShowWithParameter(str);
            
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
            */
            //catalog.Show();
            

        }
    }
}