using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

    // Fogon
public class StoveSlot:Slot
{
    public List<Item> itemsList;
    public void Start()
    {
        
    }
    public override void LeaveObjOn(CharacterControllerAct player)
    {
     //   if(player.attachedObject.GetComponent<Item>()!=null)
        base.LeaveObjOn(player);
    }

}

