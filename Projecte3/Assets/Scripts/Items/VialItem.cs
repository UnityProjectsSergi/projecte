using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class VialItem : Item
{
    public List<Item> listItem;
    //Get Vial Item from VialItemPool
    public void Start()
    {
        rigidbodyController = GetComponent<RigidbodyController>();
        itemType = ItemType.Vial;
    }
    public void ResetVial()
    {
        listItem.Clear();
    }
}

