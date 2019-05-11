using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using Assets.Scripts.ObjPooler;
using UnityEngine.UI;
// Fogon
public class StoveSlot : Slot
{
    // el foc
    public bool hasPassIngToVial;

    // get ItemPot from ItemPotPool.

    public void Start()
    {
        item = PotPool.Instance.GetObjFromPool(positionObjOn);       
        item.transform.parent = positionObjOn.transform;
    }

    public override void LeaveObjOn(CharacterControllerAct player)
    {
        /// si tinc objecte a sobre
        if (item != null)
        {
            // si obj q tinx es pot
            if (item.itemType == ItemType.Pot)
            {
                // si player be amb obj i es ingredient
                Item itemPlayer = player.attachedObject.GetComponent<Item>();
                if (itemPlayer.itemType == ItemType.Ing)
                {
                    /// si ingredient esta cutted
                    if (itemPlayer.stateIngredient == StateIngredient.cutted)
                    {
                        //clono itemplayer
                       
                        Item ItemClonIngredient = itemPlayer.Clone();
                        ItemPot itempot = item.GetComponent<ItemPot>();

                        //s al agafa el ing fets del pot 
                        if (itempot.listItem.Count < itempot.potUi.listUIItems.Count)
                        {
                            if (itempot.currentStatePot != ItemPotStateIngredients.Burning || itempot.currentStatePot != ItemPotStateIngredients.BurnedToTrash)
                            {
                              
                                //Affegeixo ItemClon a llista items del ItemPot que tinc a sobre  
                                if (itempot.LeaveObjIn(ItemClonIngredient))
                                {
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
                }
                else if (itemPlayer.itemType == ItemType.Vial)
                {
                    ItemPot ItemPot = item.GetComponent<ItemPot>();
                    if (!hasPassIngToVial)
                    {
                        Debug.Log(ItemPot.currentStatePot);
                        if (ItemPot.currentStatePot == ItemPotStateIngredients.Alert || ItemPot.currentStatePot == ItemPotStateIngredients.CookedDone)
                        {
                            player.attachedObject.GetComponent<VialItem>().listItem = new List<Item>(ItemPot.listItem);
                            player.attachedObject.GetComponent<VialItem>().ChangeMaterial();
                            ItemPot.ResetPot();
                            hasPassIngToVial = true;
                        }
                        else
                        {
                            //Todo ErrorOnScreen
                        }
                    }
                 
                }
            }
        }
        else
        {
            Item itemPlayer = player.attachedObject.GetComponent<Item>();
            if (itemPlayer.itemType == ItemType.Pot)
                base.LeaveObjOn(player);
        }
        // mirar al joc si es poden fgr 
    }

    public override void Catch(CharacterControllerAct player)
    {
        if (player.attachedObject == null)
        {
            base.Catch(player);
        }
    }


    public bool CheckIsCookedIng()
    {
        return true;
    }

}

