using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Maui_App.Model;

class Store
{

    public double Quantity_Store { get => Quantity_Store; set => Quantity_Store = value; }
    public string Name { get => Name; set => Name = value; }

    public Store(string name, double quantity_Store)
    {
        this.Name = name;
        this.Quantity_Store = quantity_Store;
    }

    public Store()
       : this("", 0)
    {
    }
}
