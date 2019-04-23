using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ItemPotFSM : Item
{
    [Header("Pot Variables")]
    public int NumIngedientsOfPot;
    public bool ShowSlotsIngEmpty;
    public List<Item> listItem;    
    public bool IsStartCooking;
    public PotUIFSM potUi;
    // saber si el que hi ha 
    public LayerMask layerMask;
    public bool hasStoveUnder;
    public FSM.FSM_Pot FSM_Pot;
    public int currentSlotList=0;
    public float totalduration;
    public int oldSlot;

    //  public  ItemPotStateIngredients currentStatePot;
    private void Awake()
    {
        FSM_Pot = GetComponent<FSM.FSM_Pot>();
    }

    public void Start()
    {
        
        listItem = new List<Item>();
       // currentStatePot = ItemPotStateIngredients.Empty;
        potUi.StartUiPot();
        itemType = ItemType.Pot;
    }
    
  
    public void LeaveObjIn(Item item)
    {
        if (currentSlotList < potUi.listUIItems.Count) 
            {
                Debug.Log("add item");
                listItem.Add(item);
                potUi.SetItemOnUISlot(currentSlotList,item);
                currentSlotList++;
                duration = item.duration;
            }
    }
   //
    public void ResetPot()
    {
      //  currentStatePot = ItemPotStateIngredients.Empty;
        IsStartCooking = false;
        listItem.Clear();
        potUi.ResetUI();
        FSM_Pot.Reset();
        currentSlotList = 0;
    }
    public bool CheckIsCookedIng()
    {
        return listItem.All(item => item.stateIngredient == StateIngredient.cooked);
    }
    
    public void Update()
    {
        DetectIfStoveIsUnder();
        if (currentSlotList != oldSlot)
        {
            totalduration += duration;
        }
        oldSlot = currentSlotList;
    }
    public void DetectIfStoveIsUnder()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up * 2f, out hit, layerMask))
        {
            StoveSlotFSM slot = hit.collider.gameObject.GetComponent<StoveSlotFSM>();
            if (slot && listItem.Count > 0)
            {
                hasStoveUnder = true;

            }
            else
            {
                hasStoveUnder = false;

            }
        }
    }
   
}

