using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.Serializable]
public class Order
{
    public int points;
    public List<Item> ingredients;
    public bool isServed;
}


