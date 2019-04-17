using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.ObjPooler;
using UnityEngine;
public class NormalSlot:Slot
{
    private bool hasPassIngToVial;

    public override void Catch(CharacterControllerAct player)
    {
        base.Catch(player);
    }
    public override void LeaveObjOn(CharacterControllerAct player)
    {
        if (item != null)
        {
            if (item.itemType == ItemType.Pot)
            {
                Item itemPlayer = player.attachedObject.GetComponent<Item>();
                if (itemPlayer.itemType == ItemType.Ing)
                {
                    if (itemPlayer.stateIngredient == StateIngredient.cutted)
                    {
                        Debug.Log("ssm");
                        //item.transform.p;arent = null;
                        Item ItemClonIngredient = itemPlayer.Clone();
                        ItemPot itempot = item.GetComponent<ItemPot>();
                        if (itempot.listItem.Count < itempot.numIng)
                        {
                            //Affegeixo ItemClon a llista items del ItemPot que tinc a sobre  
                            itempot.LeaveObjIn(ItemClonIngredient);

                            // desparent the player attached obj 
                            player.attachedObject = null;
                            // put the ItemClonIngredient  child of itemPot
                            ItemClonIngredient.transform.parent = item.transform;
                            // if ItemPlayer type is Ingredient2
                            if (itemPlayer.GetType() == typeof(Ingredient2))
                                // return to pool
                                Ingredient2Pool.Instance.ReturnToPool(itemPlayer.GetComponent<Ingredient2>());
                            else
                                //Return to pool
                                Ing1Pool.Instance.ReturnToPool(itemPlayer.GetComponent<Ing11>());
                            // flag xq no pugui afegir 2 cops els igredients
                            hasPassIngToVial = false;
                        }
                    }
                }
            }
            else if (item.itemType == ItemType.Vial)
            {
                Item i = player.attachedObject.GetComponent<Item>();
                if (i.itemType == ItemType.Pot)
                {

                }
            }
        }
        else
        base.LeaveObjOn(player);
    }
}

