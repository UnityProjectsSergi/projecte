using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using Assets.Scripts.ObjPooler;
using UnityEngine.UI;
using System.Collections;
// Fogon
public class StoveSlotFSM : Slot
{
    public GameObject FireBurnPot;
    public bool hasPassIngToVial;
    public bool ShowSlotsInUI;
    public int numIngOfPot;
    // get ItemPot from ItemPotPool.
    public void setFireStoveFromPot()
    {
        if(FireBurnPot!=null)
        {
            FireBurnPot.gameObject.SetActive(true);
        }
    }
    public void Start()
    {
        item = PotPoolFSM.Instance.GetObjFromPool(positionObjOn);
        item.GetComponent<ItemPotFSM>().Init(ShowSlotsInUI, numIngOfPot);
        
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
                        ItemPotFSM itempot = item.GetComponent<ItemPotFSM>();


                        if (itempot.listItem.Count < itempot.potUi.listUIItems.Count)
                        {
                            if (itempot.FSM_Pot.currentState == FSM.FSM_Pot.States.PAUSERUNNING || itempot.FSM_Pot.currentState == FSM.FSM_Pot.States.EMPTY) { 
                          //  if (itempot.currentStatePot != ItemPotStateIngredients.Burning || itempot.currentStatePot != ItemPotStateIngredients.BurnedToTrash)
                            //{
                                //Affegeixo ItemClon a llista items del ItemPot que tinc a sobre  
                                itempot.LeaveObjIn(ItemClonIngredient);

                                // desparent the player attached obj 


                                // put the ItemClonIngredient  child of itemPot
                                //   ItemClonIngredient.transform.parent = item.transform;
                                // if ItemPlayer type is Ingredient2
                                if (itemPlayer.GetType() == typeof(Ingredient2))
                                {
                                    // return to pool
                                    Ingredient2Pool.Instance.ReturnToPool(itemPlayer.GetComponent<Ingredient2>());
                                    Ingredient2Pool.Instance.ReturnToPool(player.attachedObject.GetComponent<Ingredient2>());
                                }
                                else
                                {   //Return to pool
                                    Ing1Pool.Instance.ReturnToPool(itemPlayer.GetComponent<Ing11>());
                                    Ing1Pool.Instance.ReturnToPool(player.attachedObject.GetComponent<Ing11>());
                                }
                            
                                hasPassIngToVial = false;
                            }
                        }
                    }
                }
                else if (itemPlayer.itemType == ItemType.Vial)
                {
                    ItemPotFSM ItemPot = item.GetComponent<ItemPotFSM>();
            
                    if (ItemPot.FSM_Pot.currentState != FSM.FSM_Pot.States.BURN)
                    {
                        player.attachedObject.GetComponent<VialItem>().listItem = new List<Item>(ItemPot.listItem);
                        ItemPot.ResetPot();
                        hasPassIngToVial = true;  
                    }
                    else
                    {
                        StartCoroutine(TextWide(5f, "Need to go trash"));
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
    public void Update()
    {

    }
    public override void Catch(CharacterControllerAct player)
    {

        if (player.attachedObject == null)
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
    private Text text;
    public IEnumerator TextWide(float num, string textO)
    {
        text.text = textO;
        yield return new WaitForSeconds(num);
        text.text = "";
    }
}

