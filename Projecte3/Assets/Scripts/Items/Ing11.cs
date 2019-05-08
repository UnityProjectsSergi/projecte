using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class Ing11:Item
    {
   
    public  void Start()
    {
        duration = 2f;
        nameO = "Ing1";
        itemType = ItemType.Ing;
        ing = ItemUiType.Ing1;
    }
}
