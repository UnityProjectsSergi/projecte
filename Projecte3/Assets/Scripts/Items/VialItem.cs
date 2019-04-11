using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class VialItem :Item
    {
        public List<Item> listItem;
    //Get Vial Item from VialItemPool
    public void Start()
    {
        itemType = ItemType.Vial;
    }
}

