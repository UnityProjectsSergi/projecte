using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    public POT_FSM2 FSM_Pot;
    public int currentSlotListCount=0;
    public float totalDurationOfCooking;
    public int oldSlot;
    public delegate void AddItemPot();
    public bool addItem;

    [Range(0,1)]
    public float FireIntensity=1f;
    public float descresesFireIntensity=0.01f;


    //  public  ItemPotStateIngredients currentStatePot;
    private void Awake()
    {
        FSM_Pot = GetComponent<POT_FSM2>();
    }

    public void Start()
    {
        
        listItem = new List<Item>();
   
        
        potUi.StartUiPot();
        itemType = ItemType.Pot;
    }
    public void Init(bool showSlotsInUI, int numIngOfPot)
    {
        ShowSlotsIngEmpty = showSlotsInUI;
        NumIngedientsOfPot = numIngOfPot;
    }  
  
    public void LeaveObjIn(Item item)
    {
        // if currentSlot if liist is minor than ui cout list
        if (currentSlotListCount < potUi.listUIItems.Count) 
        {
            Debug.Log("add item");
          
            listItem.Add(item);
            // set items on ui
            potUi.SetItemOnUISlot(currentSlotListCount,item);
            // increment currentSlotInlIst 
            currentSlotListCount++;
          
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
        FSM_Pot.resetFSM=true;
        currentSlotListCount = 0;
    }
    public bool CheckIsCookedIng()
    {
        return listItem.All(item => item.stateIngredient == StateIngredient.cooked);
    }
    
    public override void Update()
    {
        base.Update();
        DetectIfStoveIsUnder();
        // si he affegit Ingredient a l llista
        if (currentSlotListCount != oldSlot)
        {
            Debug.Log("addditemopot");
            // add duration to totalduration of ing
            totalDurationOfCooking += duration;
        }
        oldSlot = currentSlotListCount;
    }
    public void DetectIfStoveIsUnder()
    {
        if (this.transform.parent)
            if(this.transform.parent.parent.GetComponent<StoveSlotFSM>())
            hasStoveUnder = true;
        else
            hasStoveUnder = false;
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, -transform.up, out hit, 0.25f,layerMask))
        //{
        //    StoveSlotFSM slot = hit.collider.gameObject.GetComponent<StoveSlotFSM>();
        //    if (slot && listItem.Count > 0)
        //    {
        //        hasStoveUnder = true;
        //    }
        //    else
        //    {
        //        hasStoveUnder = false;
        //    }
        //}
        //else
        //    hasStoveUnder = false;

    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, -transform.up * 0.25f);
    }

}

