using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ItemPot : Item
{
    [Header("Pot Variables")]
    public int NumIngedientsOfPot;
    public bool ShowSlotsIngEmpty;
    public List<Item> listItem;    
    public bool IsStartCooking;
    public PotUI potUi;
    // saber si el que hi ha 
    public LayerMask layerMask;
    public  ItemPotStateIngredients currentStatePot;
   
    public void Start()
    {
        
        listItem = new List<Item>();
        currentStatePot = ItemPotStateIngredients.Empty;
        potUi.StartUiPot();
        itemType = ItemType.Pot;
    }
    
  
    public void LeaveObjIn(Item item)
    {
       // Son diferent crec jo tinc varies duracions una ui 
        listItem.Add(item);
        potUi.SetItemOnUISlot(item);
        currentStatePot = ItemPotStateIngredients.Cooking;
     //  potUi.potUIBar.AddDuration(item.duration);
      // item.StartCoroutine(item.Cook());
     
    }
   //
    public void ResetPot()
    {
        currentStatePot = ItemPotStateIngredients.Empty;
        IsStartCooking = false;
        listItem.Clear();
        potUi.ResetUI();
    }
    public bool CheckIsCookedIng()
    {
        return listItem.All(item => item.stateIngredient == StateIngredient.cooked);
    }
    public bool hasStoveUnder;
    public void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up * 2f,out hit, layerMask))
        {
            StoveSlot slot= hit.collider.gameObject.GetComponent<StoveSlot>();
            if (slot  && listItem.Count>0)
            {
                hasStoveUnder = true;
                potUi.hasStoveUnder = true;
            }
            else
            {
                hasStoveUnder = false;
                potUi.hasStoveUnder = false;
            }
        }
        
       
    }
   
}

