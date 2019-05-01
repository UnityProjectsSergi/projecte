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
    [HideInInspector]
    public bool ShowSlotsIngEmpty;
    public List<Item> listItem;    
    public bool IsStartCooking;
    public PotUIFSM potUi;
    // saber si el que hi ha 
    public LayerMask layerMask;
    public bool hasStoveUnder;
    public FSM.FSM_Pot FSM_Pot;
    public int currentSlotList=0;
    public float totalDurationOfCooking;
    public int oldSlot;

    //  public  ItemPotStateIngredients currentStatePot;
    private void Awake()
    {
        FSM_Pot = GetComponent<FSM.FSM_Pot>();
    }

    public void Start()
    {
        
        listItem = new List<Item>();
        
        potUi.StartUiPot();
        itemType = ItemType.Pot;
    }
    
  
    public void LeaveObjIn(Item item)
    {
        // if currentSlot if liist is minor than ui cout list
        if (currentSlotList < potUi.listUIItems.Count) 
        {
            Debug.Log("add item");
            listItem.Add(item);
            // set items on ui
            potUi.SetItemOnUISlot(currentSlotList,item);
            // increment currentSlotInlIst 
            currentSlotList++;
            //Save Duraton of ing
            duration = item.duration;
        }
    }
   //
    public void ResetPot()
    {
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
        // si he affegit Ingredient a l llista
        if (currentSlotList != oldSlot)
        {
            // add duration to totalduration of ing
            totalDurationOfCooking += duration;
        }
        oldSlot = currentSlotList;
    }
    public void DetectIfStoveIsUnder()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up * 0.3f, out hit, layerMask))
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
    public void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, -transform.up * 0.3f);
    }

}

