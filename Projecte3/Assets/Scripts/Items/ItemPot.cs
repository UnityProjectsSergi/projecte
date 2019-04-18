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
    public List<Item> tempListItem;
    public void Start()
    {
        
        listItem = new List<Item>();
        potUi.StartUiPot();
        itemType = ItemType.Pot;
    }
  
    public void LeaveObjOnItTemp(Item item)
    {
        tempListItem.Add(item)
    }
    public void LeaveObjIn(Item item)
    {
       
        listItem.Add(item);
        potUi.SetItemOnUISlot(item);

    }
   
    public void ResetPot()
    {
        
        IsStartCooking = false;
        listItem.Clear();
        potUi.Reset();
    }
    public bool CheckIsCookedIng()
    {
        return true;
    }
    public void Update()
    {
        if (listItem.Count == 1)
        {
            
        }
    }
   
}

