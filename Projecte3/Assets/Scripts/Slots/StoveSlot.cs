using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using Assets.Scripts.ObjPooler;
    // Fogon
public class StoveSlot:Slot
{
  
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
                item.GetComponent<ItemPot>().LeaveObjIn(m);
                player.attachedObject = null;
                m.transform.parent=item.transform;
                
                Ing1Pool.Instance.ReturnToPool(i.GetComponent<Ing11>());
            }
        }
        else if(i.itemType==ItemType.Pot)
        {
            base.LeaveObjOn(player);
        }
    }
    public void Update()
    {
        
    }
    public void Catch(CharacterControllerAct player)
    {
        if(player.attachedObject.GetComponent<VialItem>())
        {

        }
        base.Catch(player);

        //item.stateIngredient = StateIngredient.cooked;
        
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

