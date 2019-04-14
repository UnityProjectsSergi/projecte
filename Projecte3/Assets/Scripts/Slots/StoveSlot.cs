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
    // el foc
    public bool hasPassIngToVial;
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
               // Ing1Pool.Instance.ReturnToPool(i.GetComponent<Ing11>());
                hasPassIngToVial = false;
            }
        }
        else if(i.itemType==ItemType.Pot)
        {
            base.LeaveObjOn(player);
        }
        else if (i.itemType == ItemType.Vial)
        {
            Debug.Log("porto vial");
            if (CheckIsCookedIng() && !hasPassIngToVial)
            {
                Debug.Log("ssspoar");
                player.attachedObject.GetComponent<VialItem>().listItem = item.GetComponent<ItemPot>().listItem;
                // jo tinc 2 llistes de ingredients
                // la de l'olla i la del pot x servir= VIAL
                // agafo ingredient ael deixo a l'olla 
                // despres vull agafar tots els ingredints d lolla i posals al vialB
                // despres d canviar els ingreddents d lloc vull vuidar l'olla 
                
                // XQ NO VULL Q I SIGUIN EN LA PROJIMA RECEPTA
                // EL PROBLEMA ES Q SI LA VUIDO NO OMLE EL VIAL
                //i x canvar 
                item.GetComponent<ItemPot>().ResetPot();
                hasPassIngToVial = true;

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

