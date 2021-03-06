using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plarium9__10
{
    [Serializable]
    public class ParamsGroup
    {
        public string Name { get; set; }
        public XmlSerializableDictionary<string, string> Params;
        ParamsGroup(){}
        public ParamsGroup(string name)
        {
            this.Name = name;
            this.Params = new();
        }
        public void ShowParams()
        {
            foreach (var param in Params)
            {
                Console.WriteLine($"\t * {param.Key}");
            }
        }
        public bool FindParam(string param)
        {
            foreach (var item in Params)
            {
                if (item.Key == param)
                {
                    return true;
                }
            }
            return false;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Группа параметров - {this.Name}");
            foreach (var param in Params)
            {
                Console.WriteLine($"\t * {param.Key} измеряется в {param.Value}");
            }
        }
    }
}
