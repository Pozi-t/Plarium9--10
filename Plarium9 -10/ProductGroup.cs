using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plarium9__10
{
    class ProductGroup
    {
        public string Name;
        public List<ParamsGroup> GroupsParams;
        public ProductGroup()
        {
            Name = "";
            GroupsParams = new List<ParamsGroup>();
        }
        public ProductGroup(string name)
        {
            this.Name = name;
            GroupsParams = new List<ParamsGroup>();
        }
        public void ShowParamsGroups()
        {
            foreach (var group in GroupsParams)
            {
                Console.WriteLine($"Группа {group.Name} :");
                group.ShowParams();
            }
        }
        public (ParamsGroup, int) FindParamsGroup(string name)
        {
            int i = 0;
            foreach (var item in GroupsParams)
            {
                if (item.Name == name)
                {
                    return (item, i);
                }
                i++;
            }
            return (null, -1);
        }
        public bool FindParaminGroup(string param)
        {
            bool find = false;

            foreach (var group in GroupsParams)
            {
                find = group.FindParam(param);
                if (find) return find;
            }

            return find;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Группа товаров - {this.Name}");
            foreach (var group in GroupsParams)
            {
                group.ShowInfo();
            }
        }

    }
}
