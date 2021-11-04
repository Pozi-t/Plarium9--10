using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Plarium9__10
{
    [Serializable]
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public ProductGroup ProductGroup;

        public Product() {}
        public Product(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.Date = DateTime.Now;
            this.ProductGroup = new ProductGroup();
        }
        public bool CheckProductParam(string param)
        {
            return ProductGroup.FindParaminGroup(param);
        }
        public bool CheckGroup(string group)
        {
            return group == ProductGroup.Name;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Продукт - {this.Name}");
            Console.WriteLine($"Описание - {this.Description}");
            Console.WriteLine($"Дата выпуска - {this.Date.ToString()}");
            ProductGroup.ShowInfo();
        }
    }
}
