using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Plarium9__10
{
    [Serializable]
    public class Catalog
    {
        List<Product> data;
        public List<Product> Data {
            get { return data; }
            set { data = value; }
        }
        public Catalog() { }
        public Catalog(bool i)
        {
            data = new();
            data.Add(new("Телефон", "Устройство связи"));
            data.Add(new("Телевизор", "устройство вывода"));
            data.Add(new("Диван", "Удобный диван"));
            data.Add(new("Кресло", "Офисное кресло"));
            data.Add(new("Труба", "Водопроводная труба"));

            data[0].ProductGroup.Name = "Техника";
            data[1].ProductGroup.Name = "Техника";
            data[2].ProductGroup.Name = "Мебель";
            data[3].ProductGroup.Name = "Мебель";
            data[4].ProductGroup.Name = "Канализация";

            //Телефон
            data[0].ProductGroup.GroupsParams.Add(new ParamsGroup("Размер"));
            data[0].ProductGroup.GroupsParams.Add(new ParamsGroup("Внешние хактеристики"));
            data[0].ProductGroup.GroupsParams.Add(new ParamsGroup("Хактеристики"));

            data[0].ProductGroup.GroupsParams[0].Params.Add("Длина", "см");
            data[0].ProductGroup.GroupsParams[0].Params.Add("Ширина", "см");
            data[0].ProductGroup.GroupsParams[0].Params.Add("Высота", "см");

            data[0].ProductGroup.GroupsParams[1].Params.Add("Корпус", "шт.");
            data[0].ProductGroup.GroupsParams[1].Params.Add("Стекла", "шт.");

            data[0].ProductGroup.GroupsParams[2].Params.Add("Процесор", "герц");
            data[0].ProductGroup.GroupsParams[2].Params.Add("ОЗУ", "МБ");
            data[0].ProductGroup.GroupsParams[2].Params.Add("Память", "МБ");

            //Телевизор
            data[1].ProductGroup.GroupsParams.Add(new ParamsGroup("Размер"));
            data[1].ProductGroup.GroupsParams.Add(new ParamsGroup("Внешние хактеристики"));
            data[1].ProductGroup.GroupsParams.Add(new ParamsGroup("Хактеристики"));


            data[1].ProductGroup.GroupsParams[0].Params.Add("Длина", "см");
            data[1].ProductGroup.GroupsParams[0].Params.Add("Ширина", "см");
            data[1].ProductGroup.GroupsParams[0].Params.Add("Высота", "см");


            data[1].ProductGroup.GroupsParams[1].Params.Add("Корпус", "шт.");
            data[1].ProductGroup.GroupsParams[1].Params.Add("Разьёмы", "шт.");

            data[1].ProductGroup.GroupsParams[2].Params.Add("Процесор", "герц");
            data[1].ProductGroup.GroupsParams[2].Params.Add("ОЗУ", "МБ");
            data[1].ProductGroup.GroupsParams[2].Params.Add("Контакты", "шт");

            //Диван
            data[2].ProductGroup.GroupsParams.Add(new ParamsGroup("Размер"));
            data[2].ProductGroup.GroupsParams.Add(new ParamsGroup("Комплектующие"));


            data[2].ProductGroup.GroupsParams[0].Params.Add("Длина", "см");
            data[2].ProductGroup.GroupsParams[0].Params.Add("Ширина", "см");
            data[2].ProductGroup.GroupsParams[0].Params.Add("Высота", "см");


            data[2].ProductGroup.GroupsParams[1].Params.Add("Набивка", "шт");
            data[2].ProductGroup.GroupsParams[1].Params.Add("Ткань", "м");
            data[2].ProductGroup.GroupsParams[1].Params.Add("Фанера", "лист");

            //Кресло
            data[3].ProductGroup.GroupsParams.Add(new ParamsGroup("Размер"));
            data[3].ProductGroup.GroupsParams.Add(new ParamsGroup("Комплектующие"));


            data[3].ProductGroup.GroupsParams[0].Params.Add("Длина", "см");
            data[3].ProductGroup.GroupsParams[0].Params.Add("Ширина", "см");
            data[3].ProductGroup.GroupsParams[0].Params.Add("Высота", "см");


            data[3].ProductGroup.GroupsParams[1].Params.Add("Набивка", "шт");
            data[3].ProductGroup.GroupsParams[1].Params.Add("Ткань", "м");
            data[3].ProductGroup.GroupsParams[1].Params.Add("Ножки", "лист");

            // Труба
            data[4].ProductGroup.GroupsParams.Add(new ParamsGroup("Размер"));
            data[4].ProductGroup.GroupsParams.Add(new ParamsGroup("Комплектующие"));


            data[4].ProductGroup.GroupsParams[0].Params.Add("Длина", "см");
            data[4].ProductGroup.GroupsParams[0].Params.Add("Ширина", "см");
            data[4].ProductGroup.GroupsParams[0].Params.Add("Высота", "см");


            data[4].ProductGroup.GroupsParams[1].Params.Add("Метал", "кг");
            data[4].ProductGroup.GroupsParams[1].Params.Add("Пластик", "кг");
        }
        // индексатор
        public Product this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
        public Product this[string name]
        {
            get
            {
                Product product = null;
                foreach (var p in data)
                {
                    if (p.Name == name)
                    {
                        product = p;
                        break;
                    }
                }
                return product;
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < data.Count; i++)
            {
                yield return data[i];
            }
        }
        public void Remove(string name)
        {
            bool contains = false;
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].CheckProductParam(name)) { 
                    data.RemoveAt(i); 
                    contains = true; 
                }
            }
            if (contains) BD.WriteCommand($"Продукт с параметром {name} найден и идалён");
            else BD.WriteCommand($"Продукт с параметром {name} не найден");
            /*IEnumerable<Product> dat =
            from d in data
            where d.CheckProductParam(name) == true
            select d;
            foreach (Product item in dat)
            {
                data.Remove(item);
            }*/

        }
        public void Show()
        {
            Console.Clear();
            foreach (var product in data)
            {
                product.ShowInfo();
            }
            BD.WriteCommand("Продемонстирован каталог всех товаров");
        }
        public int FindProductOfName(string name)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Name == name) return i;
            }
            return -1;
        }
        public void MoveParameterGroup(string firstName, string secondName, string groupParam)
        {
            try
            {
                int firstId = FindProductOfName(firstName);
                int secondId = FindProductOfName(secondName);

                Console.WriteLine($"{firstId} {secondId}");
                (ParamsGroup, int) temp = data[secondId].ProductGroup.FindParamsGroup(groupParam);
                data[firstId].ProductGroup.GroupsParams.Add(temp.Item1);
                data[secondId].ProductGroup.GroupsParams.RemoveAt(temp.Item2);

                BD.WriteCommand($"Группа параметров {temp.Item1.Name} была перенесена из товара {data[firstId].Name} в товар {data[secondId].Name}");
            }
            catch (Exception e)
            {
                BD.WriteCommand($"перенос группы параметр не удался. Ошибка: {e.Message}");
            }
        }
        public void ShowWithoutParameter(string param)
        {
            /*var selectedProduct = from product in data // определяем каждый объект из teams как t
                                  where !product.CheckProductParam(param) //фильтрация по критерию
                                  select product; // выбираем объект*/
            var selectedProduct = data.Where(p => p.CheckProductParam(param) == false).Select(p => p);
            foreach (var item in selectedProduct)
            {
                Console.WriteLine($"Продукт {item.Name} не содержит параметр {param}");
            }
            BD.WriteCommand($"Продемонстрированы не содержащие параметр {param}");
        }
        public void ShowWithParameter(string param)
        {
            var selectedProduct = data.Where(p => p.CheckGroup(param)).Select(p => p);

            foreach (Product product in selectedProduct)
            {
                Console.WriteLine($"{product.Name} входит в выбранную группу");
                product.ShowInfo();
            }
            BD.WriteCommand($"Продемонстрированы содержащие параметр {param}");
        }
        public void Add(Product p)
        {
            data.Add(p);
            BD.WriteCommand($"В каталог добавлен продукт {p.Name}");
        }
    }
}
