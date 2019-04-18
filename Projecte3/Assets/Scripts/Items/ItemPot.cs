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
 
    public LayerMask layerMask;

    public void Start()
    {    
        listItem = new List<Item>();
    
        potUi.StartUiPot();
        itemType = ItemType.Pot;
    }
    
    public void LeaveObjOnItTemp(Item item)
    {
       
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
        potUi.ResetUI();
    }
    public bool CheckIsCookedIng()
    {
        return true;
    }
    public bool hasStoveUnder;
    public void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up * 2f,out hit, layerMask))
        {
            StoveSlot slot= hit.collider.gameObject.GetComponent<StoveSlot>();
            if (slot)
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

