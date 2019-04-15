using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ItemPot : Item
{
    public List<Item> listItem;
   
    public void Start()
    {
        listItem = new List<Item>();
        itemType = ItemType.Pot;
    }
    public void LeaveObjIn(Item item)
    {
        listItem.Add(item);
    }
    public void ResetPot()
    {
        listItem.Clear();
    }
}

