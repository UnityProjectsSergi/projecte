﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using Assets.Scripts.ObjPooler;
    // Fogon
public class StoveSlot:Slot
{
  // el foc
    // get ItemPot from ItemPotPool.
    public void Start()
    {
        item = PotPool.Instance.GetObjFromPool(positionObjOn);
        item.transform.parent = transform;
    }
    public override void LeaveObjOn(CharacterControllerAct player)
    {
        
        Item i = player.attachedObject.GetComponent<Item>();
        if (i.itemType==ItemType.Ing)
        {
            if (i.stateIngredient == StateIngredient.cutted)
            {
                Debug.Log("ssm");
                //item.transform.parent = null;
                Item m = i;
                Debug.Log(m);
                item.GetComponent<ItemPot>().LeaveObjIn(m);
                player.attachedObject = null;
                m.transform.parent = item.transform;
                Ing1Pool.Instance.ReturnToPool(i.GetComponent<Ing11>());
            }
        }
        else if(i.itemType==ItemType.Pot)
        {
            base.LeaveObjOn(player);
        }
        else if (i.itemType == ItemType.Vial)
        {
            Debug.Log("porto vial");
            if (CheckIsCookedIng())
            {
                Debug.Log("ssspoar");
                player.attachedObject.GetComponent<VialItem>().listItem = item.GetComponent<ItemPot>().listItem;
                item.GetComponent<ItemPot>().ResetPot();
            }
            else
            {
                //Todo ErrorOnScreen
            }
        }
    }
    public void Update()
    {
        
    }
    public void Catch(CharacterControllerAct player)
    {
        // si player te fracco i recepta feta 
        //passar ing dde olla a frasco
        // sino sta feta recpta i tens frasco no agafes recepte  

        if (player.attachedObject.GetComponent<Item>().itemType == ItemType.Vial)
        {
          
        }
        else if (player.attachedObject == null)
        {
            base.Catch(player);
        }
   
   
    }
    /// <summary>
    /// Check if all ingredients are cooked
    /// </summary>
    /// <returns>true if are cooked false if not</returns>
    public bool CheckIsCookedIng()
    {
        return true;
    }
}

